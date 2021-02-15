using AgileIQ.Test.Infrastructure;
using CcsSso.DbModel.Entity;
using CcsSso.Domain.Constants;
using CcsSso.Domain.Contracts;
using CcsSso.Domain.Dtos.External;
using CcsSso.Domain.Exceptions;
using CcsSso.Service.External;
using CcsSso.Tests.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
namespace CcsSso.Tests.External
{
  public class ContactsHelperServiceTest
  {
    public class GetContactPersonNameTuple
    {
      public static IEnumerable<object[]> CorrectContactData =>
            new List<object[]>
            {
                new object[]
                {
                    new List<Contact>{},
                    string.Empty, string.Empty
                },
                new object[]
                {
                    null,
                    string.Empty, string.Empty
                },
                new object[]
                {
                    new List<Contact>{
                      DtoHelper.GetContact("WrongName", string.Empty),
                      DtoHelper.GetContact(VirtualContactTypeName.Email, "tuser@mail.com"),
                      DtoHelper.GetContact(VirtualContactTypeName.Phone, "12312"),
                    },
                    string.Empty, string.Empty
                },
                new object[]
                {
                    new List<Contact>{
                      DtoHelper.GetContact(VirtualContactTypeName.Name, "Test User"),
                      DtoHelper.GetContact(VirtualContactTypeName.Email, "tuser@mail.com"),
                      DtoHelper.GetContact(VirtualContactTypeName.Phone, "12312"),
                    },
                    "Test", "User"
                },
                new object[]
                {
                    new List<Contact>{
                      DtoHelper.GetContact(VirtualContactTypeName.Name, "Test Middle User"),
                      DtoHelper.GetContact(VirtualContactTypeName.Email, "tuser@mail.com")
                    },
                    "Test", "User"
                },
                new object[]
                {
                    new List<Contact>{
                      DtoHelper.GetContact(VirtualContactTypeName.Name, " Test User "),
                      DtoHelper.GetContact(VirtualContactTypeName.Email, "tuser@mail.com"),
                      DtoHelper.GetContact(VirtualContactTypeName.Phone, "12312"),
                    },
                    "Test", "User"
                },
            };

      [Theory]
      [MemberData(nameof(CorrectContactData))]
      public async Task ReturnCorrectNameTuple(List<Contact> contacts, string expectedFirstName, string expectedLastName)
      {
        await DataContextHelper.ScopeAsync(async dataContext =>
        {
          await SetupTestDataAsync(dataContext);
          var contactHelperService = GetContactHelperService(dataContext);

          var (firstName, lastName) = contactHelperService.GetContactPersonNameTuple(contacts);

          Assert.Equal(expectedFirstName, firstName);
          Assert.Equal(expectedLastName, lastName);

        });
      }
    }

    public class GetContactPointReasonId
    {
      [Theory]
      [InlineData("OTHER", 1)]
      [InlineData("SHIPPING", 2)]
      [InlineData("BILLING", 3)]
      public async Task ReturnsCorrectContactReasonId_WhenCorrectReason(string reason, int expectedId)
      {
        await DataContextHelper.ScopeAsync(async dataContext =>
        {
          await SetupTestDataAsync(dataContext);
          var contactHelperService = GetContactHelperService(dataContext);

          var result = await contactHelperService.GetContactPointReasonIdAsync(reason);

          Assert.Equal(expectedId, result);

        });
      }

      [Theory]
      [InlineData("INVALID")]
      [InlineData("other")]
      public async Task ThrowsException_WhenIncorrectContactReason(string reason)
      {
        await DataContextHelper.ScopeAsync(async dataContext =>
        {
          await SetupTestDataAsync(dataContext);
          var contactHelperService = GetContactHelperService(dataContext);

          var ex = await Assert.ThrowsAsync<CcsSsoException>(() => contactHelperService.GetContactPointReasonIdAsync(reason));
          Assert.Equal(ErrorConstant.ErrorInvalidContactReason, ex.Message);
        });
      }
    }

    public class ValidateContacts
    {
      public static IEnumerable<object[]> InCorrectContactData =>
            new List<object[]>
            {
                new object[]
                {
                    new List<Contact>{},
                    ErrorConstant.ErrorInvalidContacts
                },
                new object[]
                {
                    null,
                    ErrorConstant.ErrorInvalidContacts
                },
                new object[]
                {
                    new List<Contact>{
                      DtoHelper.GetContact("WrongName", string.Empty),
                      DtoHelper.GetContact(VirtualContactTypeName.Email, "tuser@mail.com"),
                      DtoHelper.GetContact(VirtualContactTypeName.Phone, "12312"),
                    },
                    ErrorConstant.ErrorInvalidContactName
                },
                new object[]
                {
                    new List<Contact>{
                      DtoHelper.GetContact(VirtualContactTypeName.Name, "Test User"),
                      DtoHelper.GetContact(VirtualContactTypeName.Email, "tusermailcom"),
                      DtoHelper.GetContact(VirtualContactTypeName.Phone, "12312"),
                    },
                    ErrorConstant.ErrorInvalidEmail
                }
            };

      [Theory]
      [MemberData(nameof(InCorrectContactData))]
      public async Task ThrowsException_WhenValidating(List<Contact> contacts,string expectedError)
      {
        await DataContextHelper.ScopeAsync(async dataContext =>
        {
          await SetupTestDataAsync(dataContext);
          var contactHelperService = GetContactHelperService(dataContext);

          var ex = Assert.Throws<CcsSsoException>(() => contactHelperService.ValidateContacts(contacts));

          Assert.Equal(expectedError, ex.Message);
        });
      }
    }

    public class AssignVirtualContactsToContactPoint
    {
      public static IEnumerable<object[]> InCorrectContactData =>
            new List<object[]>
            {
                new object[]
                {
                    new List<Contact>{
                      DtoHelper.GetContact(VirtualContactTypeName.Name, "Name last"),
                      DtoHelper.GetContact(VirtualContactTypeName.Email, "tuser@mail.com"),
                      DtoHelper.GetContact(VirtualContactTypeName.Phone, "12312"),
                    },
                    new ContactPoint{
                      ContactPointReasonId = 1,
                      ContactDetail = new ContactDetail
                      {
                        EffectiveFrom = DateTime.UtcNow
                      }
                    },
                    2
                },
            };

      [Theory]
      [MemberData(nameof(InCorrectContactData))]
      public async Task UpdateContactPointObjectSuccessfully(List<Contact> contacts, ContactPoint contactPoint, int expectedVirtualAddressCount)
      {
        await DataContextHelper.ScopeAsync(async dataContext =>
        {
          await SetupTestDataAsync(dataContext);
          var contactHelperService = GetContactHelperService(dataContext);

          await contactHelperService.AssignVirtualContactsToContactPointAsync(contacts, contactPoint);

          Assert.Equal(expectedVirtualAddressCount, contactPoint.ContactDetail.VirtualAddresses.Count);

          var email = contactPoint.ContactDetail.VirtualAddresses.FirstOrDefault(v => v.VirtualAddressTypeId == 1).VirtualAddressValue;
          var phone = contactPoint.ContactDetail.VirtualAddresses.FirstOrDefault(v => v.VirtualAddressTypeId == 2).VirtualAddressValue;

          Assert.Equal(contacts.FirstOrDefault(c => c.ContactName == VirtualContactTypeName.Email).ContactValue, email);
          Assert.Equal(contacts.FirstOrDefault(c => c.ContactName == VirtualContactTypeName.Phone).ContactValue, phone);
        });
      }
    }

    public static ContactsHelperService GetContactHelperService(IDataContext dataContext)
    {
      var service = new ContactsHelperService(dataContext);
      return service;
    }

    public static async Task SetupTestDataAsync(IDataContext dataContext)
    {
      dataContext.VirtualAddressType.Add(new VirtualAddressType { Id = 1, Name = VirtualContactTypeName.Email, Description = "email" });
      dataContext.VirtualAddressType.Add(new VirtualAddressType { Id = 2, Name = VirtualContactTypeName.Phone, Description = "phone" });
      dataContext.VirtualAddressType.Add(new VirtualAddressType { Id = 3, Name = VirtualContactTypeName.Fax, Description = "fax" });
      dataContext.VirtualAddressType.Add(new VirtualAddressType { Id = 4, Name = VirtualContactTypeName.Url, Description = "url" });

      dataContext.ContactPointReason.Add(new ContactPointReason { Id = 1, Name = "OTHER", Description = "Other" });
      dataContext.ContactPointReason.Add(new ContactPointReason { Id = 2, Name = "SHIPPING", Description = "Shipping" });
      dataContext.ContactPointReason.Add(new ContactPointReason { Id = 3, Name = "BILLING", Description = "Billing" });

      await dataContext.SaveChangesAsync();
    }
  }
}
