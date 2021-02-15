--
-- PostgreSQL database dump
--

-- Dumped from database version 12.5
-- Dumped by pg_dump version 12.5

-- Started on 2021-02-05 16:24:19

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 1 (class 3079 OID 16384)
-- Name: adminpack; Type: EXTENSION; Schema: -; Owner: -
--

CREATE EXTENSION IF NOT EXISTS adminpack WITH SCHEMA pg_catalog;


--
-- TOC entry 3146 (class 0 OID 0)
-- Dependencies: 1
-- Name: EXTENSION adminpack; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION adminpack IS 'administrative functions for PostgreSQL';


--
-- TOC entry 226 (class 1259 OID 16858)
-- Name: postgres_increment_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.postgres_increment_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
    CYCLE;


ALTER TABLE public.postgres_increment_seq OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 204 (class 1259 OID 16400)
-- Name: CcsAccessRole; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."CcsAccessRole" (
    "CcsAccessRoleName" text,
    "CcsAccessRoleDescription" text,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL
);


ALTER TABLE public."CcsAccessRole" OWNER TO postgres;

--
-- TOC entry 243 (class 1259 OID 17258)
-- Name: CcsAccessRole_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."CcsAccessRole_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."CcsAccessRole_Id_seq" OWNER TO postgres;

--
-- TOC entry 3147 (class 0 OID 0)
-- Dependencies: 243
-- Name: CcsAccessRole_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."CcsAccessRole_Id_seq" OWNED BY public."CcsAccessRole"."Id";


--
-- TOC entry 214 (class 1259 OID 16525)
-- Name: ContactDetail; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ContactDetail" (
    "ContactPointId" integer NOT NULL,
    "EffectiveFrom" timestamp without time zone NOT NULL,
    "EffectiveTo" timestamp without time zone NOT NULL,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL
);


ALTER TABLE public."ContactDetail" OWNER TO postgres;

--
-- TOC entry 232 (class 1259 OID 17048)
-- Name: ContactDetail_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."ContactDetail_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."ContactDetail_Id_seq" OWNER TO postgres;

--
-- TOC entry 3148 (class 0 OID 0)
-- Dependencies: 232
-- Name: ContactDetail_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."ContactDetail_Id_seq" OWNED BY public."ContactDetail"."Id";


--
-- TOC entry 211 (class 1259 OID 16475)
-- Name: ContactPoint; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ContactPoint" (
    "PartyId" integer NOT NULL,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL,
    "ContactPointReasonId" integer DEFAULT 1
);


ALTER TABLE public."ContactPoint" OWNER TO postgres;

--
-- TOC entry 250 (class 1259 OID 24593)
-- Name: ContactPointReason; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ContactPointReason" (
    "Id" integer NOT NULL,
    "Name" text,
    "Description" text,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea
);


ALTER TABLE public."ContactPointReason" OWNER TO postgres;

--
-- TOC entry 249 (class 1259 OID 24591)
-- Name: ContactPointReason_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."ContactPointReason" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."ContactPointReason_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 231 (class 1259 OID 17029)
-- Name: ContactPoint_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."ContactPoint_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."ContactPoint_Id_seq" OWNER TO postgres;

--
-- TOC entry 3149 (class 0 OID 0)
-- Dependencies: 231
-- Name: ContactPoint_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."ContactPoint_Id_seq" OWNED BY public."ContactPoint"."Id";


--
-- TOC entry 205 (class 1259 OID 16410)
-- Name: EnterpriseType; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."EnterpriseType" (
    "EnterpriseTypeName" text,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL
);


ALTER TABLE public."EnterpriseType" OWNER TO postgres;

--
-- TOC entry 246 (class 1259 OID 17310)
-- Name: EnterpriseType_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."EnterpriseType_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."EnterpriseType_Id_seq" OWNER TO postgres;

--
-- TOC entry 3150 (class 0 OID 0)
-- Dependencies: 246
-- Name: EnterpriseType_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."EnterpriseType_Id_seq" OWNED BY public."EnterpriseType"."Id";


--
-- TOC entry 206 (class 1259 OID 16420)
-- Name: IdentityProvider; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."IdentityProvider" (
    "IdpUri" text,
    "IdpName" text,
    "ExternalIdpFlag" boolean NOT NULL,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "Id" bigint NOT NULL
);


ALTER TABLE public."IdentityProvider" OWNER TO postgres;

--
-- TOC entry 227 (class 1259 OID 16933)
-- Name: IdentityProvider_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."IdentityProvider_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."IdentityProvider_Id_seq" OWNER TO postgres;

--
-- TOC entry 3151 (class 0 OID 0)
-- Dependencies: 227
-- Name: IdentityProvider_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."IdentityProvider_Id_seq" OWNED BY public."IdentityProvider"."Id";


--
-- TOC entry 212 (class 1259 OID 16490)
-- Name: Organisation; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Organisation" (
    "OrganisationUri" text,
    "RightToBuy" boolean NOT NULL,
    "PartyId" integer NOT NULL,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "CiiOrganisationId" text,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL,
    "LegalName" text
);


ALTER TABLE public."Organisation" OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 16540)
-- Name: OrganisationAccessRole; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."OrganisationAccessRole" (
    "OrganisationId" integer NOT NULL,
    "OrganisationAccessRoleName" text,
    "OrganisationAccessRoleDescription" text,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL
);


ALTER TABLE public."OrganisationAccessRole" OWNER TO postgres;

--
-- TOC entry 247 (class 1259 OID 17328)
-- Name: OrganisationAccessRole_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."OrganisationAccessRole_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."OrganisationAccessRole_Id_seq" OWNER TO postgres;

--
-- TOC entry 3152 (class 0 OID 0)
-- Dependencies: 247
-- Name: OrganisationAccessRole_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."OrganisationAccessRole_Id_seq" OWNED BY public."OrganisationAccessRole"."Id";


--
-- TOC entry 216 (class 1259 OID 16555)
-- Name: OrganisationEnterpriseType; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."OrganisationEnterpriseType" (
    "OrganisationId" integer NOT NULL,
    "EnterpriseTypeId" integer NOT NULL,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL
);


ALTER TABLE public."OrganisationEnterpriseType" OWNER TO postgres;

--
-- TOC entry 245 (class 1259 OID 17294)
-- Name: OrganisationEnterpriseType_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."OrganisationEnterpriseType_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."OrganisationEnterpriseType_Id_seq" OWNER TO postgres;

--
-- TOC entry 3153 (class 0 OID 0)
-- Dependencies: 245
-- Name: OrganisationEnterpriseType_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."OrganisationEnterpriseType_Id_seq" OWNED BY public."OrganisationEnterpriseType"."Id";


--
-- TOC entry 235 (class 1259 OID 17102)
-- Name: Organisation_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Organisation_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Organisation_Id_seq" OWNER TO postgres;

--
-- TOC entry 3154 (class 0 OID 0)
-- Dependencies: 235
-- Name: Organisation_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Organisation_Id_seq" OWNED BY public."Organisation"."Id";


--
-- TOC entry 210 (class 1259 OID 16460)
-- Name: Party; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Party" (
    "PartyTypeId" integer NOT NULL,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL
);


ALTER TABLE public."Party" OWNER TO postgres;

--
-- TOC entry 207 (class 1259 OID 16430)
-- Name: PartyType; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PartyType" (
    "PartyTypeName" text,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL
);


ALTER TABLE public."PartyType" OWNER TO postgres;

--
-- TOC entry 248 (class 1259 OID 17347)
-- Name: PartyType_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."PartyType_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."PartyType_Id_seq" OWNER TO postgres;

--
-- TOC entry 3155 (class 0 OID 0)
-- Dependencies: 248
-- Name: PartyType_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."PartyType_Id_seq" OWNED BY public."PartyType"."Id";


--
-- TOC entry 229 (class 1259 OID 16980)
-- Name: Party_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Party_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Party_Id_seq" OWNER TO postgres;

--
-- TOC entry 3156 (class 0 OID 0)
-- Dependencies: 229
-- Name: Party_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Party_Id_seq" OWNED BY public."Party"."Id";


--
-- TOC entry 217 (class 1259 OID 16575)
-- Name: Person; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Person" (
    "OrganisationId" integer NOT NULL,
    "PartyId" integer NOT NULL,
    "Title" integer NOT NULL,
    "FirstName" text,
    "LastName" text,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL
);


ALTER TABLE public."Person" OWNER TO postgres;

--
-- TOC entry 230 (class 1259 OID 17014)
-- Name: Person_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Person_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Person_Id_seq" OWNER TO postgres;

--
-- TOC entry 3157 (class 0 OID 0)
-- Dependencies: 230
-- Name: Person_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Person_Id_seq" OWNED BY public."Person"."Id";


--
-- TOC entry 222 (class 1259 OID 16660)
-- Name: PhysicalAddress; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PhysicalAddress" (
    "StreetAddress" text,
    "Locality" text,
    "Region" text,
    "PostalCode" text,
    "CountryCode" text,
    "Uprn" text,
    "ContactDetailId" integer NOT NULL,
    "CreatedPartyId" integer,
    "LastUpdatedPartyId" integer,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone,
    "IsDeleted" boolean,
    "ConcurrencyKey" bytea,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL
);


ALTER TABLE public."PhysicalAddress" OWNER TO postgres;

--
-- TOC entry 233 (class 1259 OID 17063)
-- Name: PhysicalAddress_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."PhysicalAddress_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."PhysicalAddress_Id_seq" OWNER TO postgres;

--
-- TOC entry 3158 (class 0 OID 0)
-- Dependencies: 233
-- Name: PhysicalAddress_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."PhysicalAddress_Id_seq" OWNED BY public."PhysicalAddress"."Id";


--
-- TOC entry 218 (class 1259 OID 16595)
-- Name: ProcurementGroup; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ProcurementGroup" (
    "OrganisationId" integer NOT NULL,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL
);


ALTER TABLE public."ProcurementGroup" OWNER TO postgres;

--
-- TOC entry 236 (class 1259 OID 17146)
-- Name: ProcurementGroup_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."ProcurementGroup_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."ProcurementGroup_Id_seq" OWNER TO postgres;

--
-- TOC entry 3159 (class 0 OID 0)
-- Dependencies: 236
-- Name: ProcurementGroup_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."ProcurementGroup_Id_seq" OWNED BY public."ProcurementGroup"."Id";


--
-- TOC entry 219 (class 1259 OID 16610)
-- Name: TradingOrganisation; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."TradingOrganisation" (
    "OrganisationId" integer NOT NULL,
    "TradingName" text,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL
);


ALTER TABLE public."TradingOrganisation" OWNER TO postgres;

--
-- TOC entry 237 (class 1259 OID 17160)
-- Name: TradingOrganisation_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."TradingOrganisation_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."TradingOrganisation_Id_seq" OWNER TO postgres;

--
-- TOC entry 3160 (class 0 OID 0)
-- Dependencies: 237
-- Name: TradingOrganisation_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."TradingOrganisation_Id_seq" OWNED BY public."TradingOrganisation"."Id";


--
-- TOC entry 213 (class 1259 OID 16505)
-- Name: User; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."User" (
    "JobTitle" text,
    "UserTitle" integer NOT NULL,
    "PartyId" integer NOT NULL,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "UserName" text,
    "IdentityProviderId" integer,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL
);


ALTER TABLE public."User" OWNER TO postgres;

--
-- TOC entry 224 (class 1259 OID 16695)
-- Name: UserAccessRole; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."UserAccessRole" (
    "UserId" integer NOT NULL,
    "CcsAccessRoleId" integer NOT NULL,
    "OrganisationAccessRoleId" integer NOT NULL,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL
);


ALTER TABLE public."UserAccessRole" OWNER TO postgres;

--
-- TOC entry 241 (class 1259 OID 17224)
-- Name: UserAccessRole_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."UserAccessRole_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."UserAccessRole_Id_seq" OWNER TO postgres;

--
-- TOC entry 3161 (class 0 OID 0)
-- Dependencies: 241
-- Name: UserAccessRole_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."UserAccessRole_Id_seq" OWNED BY public."UserAccessRole"."Id";


--
-- TOC entry 220 (class 1259 OID 16625)
-- Name: UserGroup; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."UserGroup" (
    "OrganisationId" integer NOT NULL,
    "UserGroupName" text,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL
);


ALTER TABLE public."UserGroup" OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 16720)
-- Name: UserGroupMembership; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."UserGroupMembership" (
    "UserGroupId" integer NOT NULL,
    "UserId" integer NOT NULL,
    "MembershipStartDate" timestamp without time zone NOT NULL,
    "MembershipEndDate" timestamp without time zone NOT NULL,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL
);


ALTER TABLE public."UserGroupMembership" OWNER TO postgres;

--
-- TOC entry 238 (class 1259 OID 17174)
-- Name: UserGroupMembership_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."UserGroupMembership_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."UserGroupMembership_Id_seq" OWNER TO postgres;

--
-- TOC entry 3162 (class 0 OID 0)
-- Dependencies: 238
-- Name: UserGroupMembership_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."UserGroupMembership_Id_seq" OWNED BY public."UserGroupMembership"."Id";


--
-- TOC entry 239 (class 1259 OID 17188)
-- Name: UserGroup_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."UserGroup_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."UserGroup_Id_seq" OWNER TO postgres;

--
-- TOC entry 3163 (class 0 OID 0)
-- Dependencies: 239
-- Name: UserGroup_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."UserGroup_Id_seq" OWNED BY public."UserGroup"."Id";


--
-- TOC entry 221 (class 1259 OID 16640)
-- Name: UserSetting; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."UserSetting" (
    "UserId" integer NOT NULL,
    "UserSettingTypeId" integer NOT NULL,
    "UserSettingValue" text,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL
);


ALTER TABLE public."UserSetting" OWNER TO postgres;

--
-- TOC entry 208 (class 1259 OID 16440)
-- Name: UserSettingType; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."UserSettingType" (
    "UserSettingName" text,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL
);


ALTER TABLE public."UserSettingType" OWNER TO postgres;

--
-- TOC entry 242 (class 1259 OID 17240)
-- Name: UserSettingType_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."UserSettingType_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."UserSettingType_Id_seq" OWNER TO postgres;

--
-- TOC entry 3164 (class 0 OID 0)
-- Dependencies: 242
-- Name: UserSettingType_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."UserSettingType_Id_seq" OWNED BY public."UserSettingType"."Id";


--
-- TOC entry 240 (class 1259 OID 17209)
-- Name: UserSetting_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."UserSetting_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."UserSetting_Id_seq" OWNER TO postgres;

--
-- TOC entry 3165 (class 0 OID 0)
-- Dependencies: 240
-- Name: UserSetting_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."UserSetting_Id_seq" OWNED BY public."UserSetting"."Id";


--
-- TOC entry 228 (class 1259 OID 16952)
-- Name: User_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."User_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."User_Id_seq" OWNER TO postgres;

--
-- TOC entry 3166 (class 0 OID 0)
-- Dependencies: 228
-- Name: User_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."User_Id_seq" OWNED BY public."User"."Id";


--
-- TOC entry 223 (class 1259 OID 16675)
-- Name: VirtualAddress; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."VirtualAddress" (
    "VirtualAddressValue" text,
    "VirtualAddressTypeId" integer NOT NULL,
    "ContactDetailId" integer NOT NULL,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL
);


ALTER TABLE public."VirtualAddress" OWNER TO postgres;

--
-- TOC entry 209 (class 1259 OID 16450)
-- Name: VirtualAddressType; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."VirtualAddressType" (
    "Name" text,
    "Description" text,
    "CreatedPartyId" integer NOT NULL,
    "LastUpdatedPartyId" integer NOT NULL,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "LastUpdatedOnUtc" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ConcurrencyKey" bytea,
    "Id" bigint DEFAULT nextval('public.postgres_increment_seq'::regclass) NOT NULL
);


ALTER TABLE public."VirtualAddressType" OWNER TO postgres;

--
-- TOC entry 244 (class 1259 OID 17276)
-- Name: VirtualAddressType_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."VirtualAddressType_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."VirtualAddressType_Id_seq" OWNER TO postgres;

--
-- TOC entry 3167 (class 0 OID 0)
-- Dependencies: 244
-- Name: VirtualAddressType_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."VirtualAddressType_Id_seq" OWNED BY public."VirtualAddressType"."Id";


--
-- TOC entry 234 (class 1259 OID 17076)
-- Name: VirtualAddress_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."VirtualAddress_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."VirtualAddress_Id_seq" OWNER TO postgres;

--
-- TOC entry 3168 (class 0 OID 0)
-- Dependencies: 234
-- Name: VirtualAddress_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."VirtualAddress_Id_seq" OWNED BY public."VirtualAddress"."Id";


--
-- TOC entry 203 (class 1259 OID 16393)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- TOC entry 2851 (class 2604 OID 16935)
-- Name: IdentityProvider Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."IdentityProvider" ALTER COLUMN "Id" SET DEFAULT nextval('public."IdentityProvider_Id_seq"'::regclass);


--
-- TOC entry 3094 (class 0 OID 16400)
-- Dependencies: 204
-- Data for Name: CcsAccessRole; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."CcsAccessRole" ("CcsAccessRoleName", "CcsAccessRoleDescription", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "Id") FROM stdin;
\.


--
-- TOC entry 3104 (class 0 OID 16525)
-- Dependencies: 214
-- Data for Name: ContactDetail; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."ContactDetail" ("ContactPointId", "EffectiveFrom", "EffectiveTo", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "Id") FROM stdin;
5	2021-02-01 16:05:57.721246	0001-01-01 00:00:00	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	6
8	2021-02-01 16:06:12.57022	0001-01-01 00:00:00	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	9
11	2021-02-01 16:12:41.844694	0001-01-01 00:00:00	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	12
14	2021-02-01 16:15:20.276245	0001-01-01 00:00:00	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	15
17	2021-02-01 16:28:02.93769	0001-01-01 00:00:00	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	18
21	2021-02-01 16:43:47.311576	0001-01-01 00:00:00	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	22
25	2021-02-01 16:44:16.894673	0001-01-01 00:00:00	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	26
29	2021-02-01 16:50:06.991093	0001-01-01 00:00:00	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	30
33	2021-02-01 17:05:18.639546	0001-01-01 00:00:00	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	34
37	2021-02-01 17:26:39.331824	0001-01-01 00:00:00	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	38
41	2021-02-01 17:32:52.074473	0001-01-01 00:00:00	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	42
93	2021-02-03 11:31:50.460958	0001-01-01 00:00:00	0	0	2021-02-03 11:31:51.031187	2021-02-03 11:31:51.031187	f	\N	95
109	2021-02-03 11:58:09.569216	0001-01-01 00:00:00	0	0	2021-02-03 11:58:09.655319	2021-02-03 11:58:09.655319	f	\N	111
176	2021-02-05 14:16:53.43111	0001-01-01 00:00:00	0	0	2021-02-05 14:16:53.525773	2021-02-05 14:16:53.525773	f	\N	177
178	2021-02-05 14:18:40.326047	0001-01-01 00:00:00	0	0	2021-02-05 14:18:40.395304	2021-02-05 14:18:40.395304	f	\N	179
182	2021-02-05 14:25:04.739174	0001-01-01 00:00:00	0	0	2021-02-05 14:25:04.795076	2021-02-05 14:25:04.795076	f	\N	183
186	2021-02-05 14:26:03.797862	0001-01-01 00:00:00	0	0	2021-02-05 14:26:03.849731	2021-02-05 14:26:03.849731	f	\N	187
191	2021-02-05 14:27:30.117932	0001-01-01 00:00:00	0	0	2021-02-05 14:27:30.167807	2021-02-05 14:27:30.167807	f	\N	192
196	2021-02-05 14:28:38.220916	0001-01-01 00:00:00	0	0	2021-02-05 14:28:38.224811	2021-02-05 14:28:38.224811	f	\N	197
201	2021-02-05 14:38:28.513814	0001-01-01 00:00:00	0	0	2021-02-05 14:38:28.569119	2021-02-05 14:38:28.569119	f	\N	202
209	2021-02-05 14:51:48.328665	0001-01-01 00:00:00	0	0	2021-02-05 14:51:48.393392	2021-02-05 14:51:48.393392	f	\N	210
217	2021-02-05 16:01:06.306132	0001-01-01 00:00:00	0	0	2021-02-05 16:01:06.360473	2021-02-05 16:01:06.360473	f	\N	218
\.


--
-- TOC entry 3101 (class 0 OID 16475)
-- Dependencies: 211
-- Data for Name: ContactPoint; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."ContactPoint" ("PartyId", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "Id", "ContactPointReasonId") FROM stdin;
4	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	5	1
7	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	8	1
10	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	11	1
13	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	14	1
16	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	17	1
20	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	21	1
24	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	25	1
28	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	29	1
32	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	33	1
36	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	37	1
40	0	0	0001-01-01 00:00:00	0001-01-01 00:00:00	f	\N	41	1
92	0	0	2021-02-03 11:31:51.031182	2021-02-03 11:31:51.031182	f	\N	93	1
108	0	0	2021-02-03 11:58:09.655315	2021-02-03 11:58:09.655315	f	\N	109	1
108	0	0	2021-02-05 14:15:06.648699	2021-02-05 14:15:06.648699	f	\N	175	0
108	0	0	2021-02-05 14:16:51.303942	2021-02-05 14:16:51.303942	f	\N	176	0
108	0	0	2021-02-05 14:18:38.703799	2021-02-05 14:18:38.703799	f	\N	178	0
181	0	0	2021-02-05 14:25:04.705954	2021-02-05 14:25:04.705954	f	\N	182	0
185	0	0	2021-02-05 14:26:03.770702	2021-02-05 14:26:03.770702	f	\N	186	0
190	0	0	2021-02-05 14:27:30.089455	2021-02-05 14:27:30.089455	f	\N	191	0
195	0	0	2021-02-05 14:28:38.215731	2021-02-05 14:28:38.215731	f	\N	196	0
200	0	0	2021-02-05 14:38:28.485977	2021-02-05 14:38:28.485977	f	\N	201	0
208	0	0	2021-02-05 14:51:48.294523	2021-02-05 14:51:48.294523	f	\N	209	0
216	0	0	2021-02-05 16:01:06.272988	2021-02-05 16:01:06.272988	f	\N	217	0
\.


--
-- TOC entry 3140 (class 0 OID 24593)
-- Dependencies: 250
-- Data for Name: ContactPointReason; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."ContactPointReason" ("Id", "Name", "Description", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey") FROM stdin;
1	OTHER	Other reason	0	0	2021-02-02 12:23:43.416421	2021-02-02 12:23:43.416421	f	\N
2	SHIPPING	Shipping	0	0	2021-02-02 12:23:54.956953	2021-02-02 12:23:54.956953	f	\N
3	BILLING	Billing	0	0	2021-02-02 12:23:54.956953	2021-02-02 12:23:54.956953	f	\N
4	MAIN_OFFICE	Main Office	0	0	2021-02-02 12:23:54.956953	2021-02-02 12:23:54.956953	f	\N
5	HEAD_QUARTERS	Head quarters	0	0	2021-02-02 12:23:54.956953	2021-02-02 12:23:54.956953	f	\N
6	MANUFACTURING	Manufacturing	0	0	2021-02-02 12:23:54.956953	2021-02-02 12:23:54.956953	f	\N
7	BRANCH	Branch	0	0	2021-02-02 12:23:54.956953	2021-02-02 12:23:54.956953	f	\N
\.


--
-- TOC entry 3095 (class 0 OID 16410)
-- Dependencies: 205
-- Data for Name: EnterpriseType; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."EnterpriseType" ("EnterpriseTypeName", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "Id") FROM stdin;
\.


--
-- TOC entry 3096 (class 0 OID 16420)
-- Dependencies: 206
-- Data for Name: IdentityProvider; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."IdentityProvider" ("IdpUri", "IdpName", "ExternalIdpFlag", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "Id") FROM stdin;
google	name goes here	f	1	1	2021-01-30 19:19:15.406463	2021-01-30 19:19:15.406543	f	\N	0
google	name goes here	f	1	1	2021-01-30 19:57:40.573887	2021-01-30 19:57:40.573978	f	\N	1
google	name goes here	f	1	1	2021-01-30 19:57:49.601702	2021-01-30 19:57:49.60171	f	\N	2
google	name goes here	f	1	1	2021-01-30 19:57:52.718232	2021-01-30 19:57:52.718237	f	\N	3
\.


--
-- TOC entry 3102 (class 0 OID 16490)
-- Dependencies: 212
-- Data for Name: Organisation; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Organisation" ("OrganisationUri", "RightToBuy", "PartyId", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "CiiOrganisationId", "Id", "LegalName") FROM stdin;
\N	t	1	1	1	2021-01-28 17:06:23.702485	2021-01-28 17:06:23.702485	f	\N	12345678	1	lee inc
http://www.google.com	t	44	44	44	2021-02-02 15:19:05.815873	2021-02-02 15:19:05.81588	f	\N	179081612279145020	45	lee inc
http://www.google.com	t	72	72	72	2021-02-02 15:49:06.200397	2021-02-02 15:49:06.200401	f	\N	42361612280946250	73	lee inc
http://www.google.com	t	77	77	77	2021-02-02 16:53:47.787273	2021-02-02 16:53:47.787275	f	\N	553221612284827970	78	lee inc
http://www.google.com	t	82	82	82	2021-02-02 17:35:34.610679	2021-02-02 17:35:34.610684	f	\N	583271612287334400	83	lee inc
http://www.google.com	t	87	87	87	2021-02-02 18:06:26.287955	2021-02-02 18:06:26.287959	f	\N	773601612289172400	88	lee inc
string	t	156	0	0	2021-02-05 13:49:06.039601	2021-02-05 13:49:06.039601	f	\N	string	157	string
string	t	185	0	0	2021-02-05 14:26:04.016723	2021-02-05 14:26:04.016723	f	\N	string	189	string
string	t	190	0	0	2021-02-05 14:27:30.326218	2021-02-05 14:27:30.326218	f	\N	string	194	string
www.bing.com	t	195	0	0	2021-02-05 14:28:38.242861	2021-02-05 14:28:38.242861	f	\N	1234567890	199	test name
www.bing.com	t	200	0	0	2021-02-05 14:38:29.397299	2021-02-05 14:38:29.397299	f	\N	1234567890	207	test name
www.bing.com	t	208	0	0	2021-02-05 14:51:48.776923	2021-02-05 14:51:48.776923	f	\N	1234567890	215	test name
\N	f	216	0	0	2021-02-05 16:01:07.026994	2021-02-05 16:01:07.026994	f	\N	\N	223	\N
\.


--
-- TOC entry 3105 (class 0 OID 16540)
-- Dependencies: 215
-- Data for Name: OrganisationAccessRole; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."OrganisationAccessRole" ("OrganisationId", "OrganisationAccessRoleName", "OrganisationAccessRoleDescription", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "Id") FROM stdin;
\.


--
-- TOC entry 3106 (class 0 OID 16555)
-- Dependencies: 216
-- Data for Name: OrganisationEnterpriseType; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."OrganisationEnterpriseType" ("OrganisationId", "EnterpriseTypeId", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "Id") FROM stdin;
\.


--
-- TOC entry 3100 (class 0 OID 16460)
-- Dependencies: 210
-- Data for Name: Party; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Party" ("PartyTypeId", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "Id") FROM stdin;
1	0	0	2021-01-28 17:06:23.702485	2021-01-28 17:06:23.702485	f	\N	1
1	0	0	2021-01-28 17:30:37.001485	2021-01-28 17:30:37.001485	f	\N	2
1	0	0	2021-01-28 17:39:09.344657	2021-01-28 17:39:09.344657	f	\N	3
3	0	0	2021-02-01 16:05:57.720723	2021-02-01 16:05:57.720823	f	\N	4
3	0	0	2021-02-01 16:06:12.570214	2021-02-01 16:06:12.570215	f	\N	7
3	0	0	2021-02-01 16:12:41.844207	2021-02-01 16:12:41.844302	f	\N	10
3	0	0	2021-02-01 16:15:20.275703	2021-02-01 16:15:20.275841	f	\N	13
3	0	0	2021-02-01 16:28:02.937147	2021-02-01 16:28:02.937254	f	\N	16
3	0	0	2021-02-01 16:43:47.311098	2021-02-01 16:43:47.311189	f	\N	20
3	0	0	2021-02-01 16:44:16.894652	2021-02-01 16:44:16.894655	f	\N	24
3	0	0	2021-02-01 16:50:06.990352	2021-02-01 16:50:06.990484	f	\N	28
3	0	0	2021-02-01 17:05:18.638973	2021-02-01 17:05:18.639104	f	\N	32
3	0	0	2021-02-01 17:26:39.331815	2021-02-01 17:26:39.331817	f	\N	36
3	0	0	2021-02-01 17:32:52.074452	2021-02-01 17:32:52.074453	f	\N	40
1	0	0	2021-02-02 15:19:05.271173	2021-02-02 15:19:05.271291	f	\N	44
3	0	0	2021-02-02 15:45:01.194099	2021-02-02 15:45:01.194203	f	\N	68
3	0	0	2021-02-02 15:46:08.751866	2021-02-02 15:46:08.751964	f	\N	69
1	0	0	2021-02-02 15:49:06.157149	2021-02-02 15:49:06.157155	f	\N	72
3	0	0	2021-02-02 15:49:06.389351	2021-02-02 15:49:06.389353	f	\N	74
1	0	0	2021-02-02 16:53:47.685573	2021-02-02 16:53:47.685578	f	\N	77
3	0	0	2021-02-02 16:53:48.090361	2021-02-02 16:53:48.090363	f	\N	79
1	0	0	2021-02-02 17:35:34.204476	2021-02-02 17:35:34.20448	f	\N	82
3	0	0	2021-02-02 17:35:34.753265	2021-02-02 17:35:34.753266	f	\N	84
1	0	0	2021-02-02 18:06:26.142131	2021-02-02 18:06:26.142135	f	\N	87
3	0	0	2021-02-02 18:06:26.457787	2021-02-02 18:06:26.457799	f	\N	89
4	0	0	2021-02-03 11:31:51.03117	2021-02-03 11:31:51.03117	f	\N	92
4	0	0	2021-02-03 11:58:09.655307	2021-02-03 11:58:09.655307	f	\N	108
1	0	0	2021-02-05 12:34:39.16212	2021-02-05 12:34:39.16212	f	\N	120
1	0	0	2021-02-05 12:34:50.398233	2021-02-05 12:34:50.398233	f	\N	122
1	0	0	2021-02-05 12:35:36.280403	2021-02-05 12:35:36.280403	f	\N	124
1	0	0	2021-02-05 12:37:57.812355	2021-02-05 12:37:57.812355	f	\N	126
1	0	0	2021-02-05 12:38:34.877685	2021-02-05 12:38:34.877685	f	\N	128
1	0	0	2021-02-05 12:39:13.326891	2021-02-05 12:39:13.326891	f	\N	130
1	0	0	2021-02-05 12:39:25.412949	2021-02-05 12:39:25.412949	f	\N	132
1	0	0	2021-02-05 12:42:05.625955	2021-02-05 12:42:05.625955	f	\N	134
1	0	0	2021-02-05 12:42:51.442468	2021-02-05 12:42:51.442468	f	\N	136
1	0	0	2021-02-05 12:45:40.334973	2021-02-05 12:45:40.334973	f	\N	138
1	0	0	2021-02-05 12:47:36.312124	2021-02-05 12:47:36.312124	f	\N	140
1	0	0	2021-02-05 12:50:29.662023	2021-02-05 12:50:29.662023	f	\N	142
1	0	0	2021-02-05 12:52:16.106241	2021-02-05 12:52:16.106241	f	\N	144
1	0	0	2021-02-05 12:54:25.225437	2021-02-05 12:54:25.225437	f	\N	146
1	0	0	2021-02-05 12:57:08.288633	2021-02-05 12:57:08.288633	f	\N	148
1	0	0	2021-02-05 13:05:48.320907	2021-02-05 13:05:48.320907	f	\N	150
1	0	0	2021-02-05 13:11:47.083727	2021-02-05 13:11:47.083727	f	\N	152
1	0	0	2021-02-05 13:47:04.569546	2021-02-05 13:47:04.569546	f	\N	154
1	0	0	2021-02-05 13:49:05.754863	2021-02-05 13:49:05.754863	f	\N	156
1	0	0	2021-02-05 13:51:55.485551	2021-02-05 13:51:55.485551	f	\N	158
1	0	0	2021-02-05 13:53:30.764089	2021-02-05 13:53:30.764089	f	\N	160
1	0	0	2021-02-05 13:55:32.914673	2021-02-05 13:55:32.914673	f	\N	162
1	0	0	2021-02-05 13:57:20.20644	2021-02-05 13:57:20.20644	f	\N	164
1	0	0	2021-02-05 13:57:47.92941	2021-02-05 13:57:47.92941	f	\N	166
1	0	0	2021-02-05 14:01:54.110057	2021-02-05 14:01:54.110057	f	\N	168
1	0	0	2021-02-05 14:03:18.59209	2021-02-05 14:03:18.59209	f	\N	170
1	0	0	2021-02-05 14:25:04.445936	2021-02-05 14:25:04.445936	f	\N	181
1	0	0	2021-02-05 14:26:03.398171	2021-02-05 14:26:03.398171	f	\N	185
1	0	0	2021-02-05 14:27:29.78415	2021-02-05 14:27:29.78415	f	\N	190
1	0	0	2021-02-05 14:28:38.194115	2021-02-05 14:28:38.194115	f	\N	195
1	0	0	2021-02-05 14:38:28.132313	2021-02-05 14:38:28.132313	f	\N	200
1	0	0	2021-02-05 14:51:47.980214	2021-02-05 14:51:47.980214	f	\N	208
1	0	0	2021-02-05 16:01:05.881288	2021-02-05 16:01:05.881288	f	\N	216
\.


--
-- TOC entry 3097 (class 0 OID 16430)
-- Dependencies: 207
-- Data for Name: PartyType; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."PartyType" ("PartyTypeName", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "Id") FROM stdin;
USER	0	0	2021-01-28 16:57:34.732024	2021-01-28 16:57:34.732024	f	\N	3
NON_USER	0	0	2021-01-28 16:57:34.732024	2021-01-28 16:57:34.732024	f	\N	4
EXTERNAL_ORGANISATION	0	0	2021-01-28 16:57:34.732024	2021-01-28 16:57:34.732024	f	\N	1
INTERNAL_ORGANISATION	0	0	2021-01-28 16:57:34.732024	2021-01-28 16:57:34.732024	f	\N	2
\.


--
-- TOC entry 3107 (class 0 OID 16575)
-- Dependencies: 217
-- Data for Name: Person; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Person" ("OrganisationId", "PartyId", "Title", "FirstName", "LastName", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "Id") FROM stdin;
1	16	1	lee	pavlou	16	16	2021-02-01 16:28:03.540976	2021-02-01 16:28:03.540985	f	\N	19
1	20	1	lee	pavlou	20	20	2021-02-01 16:43:47.900155	2021-02-01 16:43:47.900164	f	\N	23
1	24	1	lee	pavlou	24	24	2021-02-01 16:44:16.982701	2021-02-01 16:44:16.982703	f	\N	27
1	28	1	lee	pavlou	28	28	2021-02-01 16:50:07.717144	2021-02-01 16:50:07.717153	f	\N	31
1	32	1	lee	pavlou	32	32	2021-02-01 17:05:19.51648	2021-02-01 17:05:19.516489	f	\N	35
1	36	1	lee	pavlou	36	36	2021-02-01 17:26:39.423133	2021-02-01 17:26:39.423136	f	\N	39
1	40	1	lee	pavlou	40	40	2021-02-01 17:32:52.199034	2021-02-01 17:32:52.199037	f	\N	43
45	69	1	Lee	Pavlou	69	69	2021-02-02 15:46:09.438826	2021-02-02 15:46:09.438834	f	\N	70
73	74	1	\N	Hadjipavlou	74	74	2021-02-02 15:49:06.398017	2021-02-02 15:49:06.398018	f	\N	75
78	79	1	\N	Pavlou	79	79	2021-02-02 16:53:48.112693	2021-02-02 16:53:48.112694	f	\N	80
83	84	1	\N	M	84	84	2021-02-02 17:35:34.761229	2021-02-02 17:35:34.761231	f	\N	85
88	89	1	\N	Hadjipavlou	89	89	2021-02-02 18:06:26.466977	2021-02-02 18:06:26.46698	f	\N	90
78	92	0	Lee		0	0	2021-02-03 11:31:51.031202	2021-02-03 11:31:51.031202	f	\N	94
78	108	0	Test	User	0	0	2021-02-03 11:58:09.655328	2021-02-03 11:58:09.655328	f	\N	110
\.


--
-- TOC entry 3112 (class 0 OID 16660)
-- Dependencies: 222
-- Data for Name: PhysicalAddress; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."PhysicalAddress" ("StreetAddress", "Locality", "Region", "PostalCode", "CountryCode", "Uprn", "ContactDetailId", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "Id") FROM stdin;
streetAddress	locality	region	postalCode	countryCode	uprn	111	0	0	2021-02-03 11:58:09.655322	2021-02-03 11:58:09.655322	f	\N	112
string	string	string	string	string	test	179	0	0	2021-02-05 14:18:40.480944	2021-02-05 14:18:40.480944	f	\N	180
string	string	string	string	string	test	183	0	0	2021-02-05 14:25:04.885273	2021-02-05 14:25:04.885273	f	\N	184
string	string	string	string	string	test	187	0	0	2021-02-05 14:26:03.929391	2021-02-05 14:26:03.929391	f	\N	188
string	string	string	string	string	test	192	0	0	2021-02-05 14:27:30.236318	2021-02-05 14:27:30.236318	f	\N	193
string	string	string	string	string	test	197	0	0	2021-02-05 14:28:38.232917	2021-02-05 14:28:38.232917	f	\N	198
string	string	string	string	string	test	202	0	0	2021-02-05 14:38:28.646301	2021-02-05 14:38:28.646301	f	\N	203
string	string	string	string	string	string	210	0	0	2021-02-05 14:51:48.490915	2021-02-05 14:51:48.490915	f	\N	211
Crescent Arts Centre	2-4 University Road	Belfast	BT7 1NH	\N	\N	218	0	0	2021-02-05 16:01:06.440809	2021-02-05 16:01:06.440809	f	\N	219
\.


--
-- TOC entry 3108 (class 0 OID 16595)
-- Dependencies: 218
-- Data for Name: ProcurementGroup; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."ProcurementGroup" ("OrganisationId", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "Id") FROM stdin;
\.


--
-- TOC entry 3109 (class 0 OID 16610)
-- Dependencies: 219
-- Data for Name: TradingOrganisation; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."TradingOrganisation" ("OrganisationId", "TradingName", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "Id") FROM stdin;
\.


--
-- TOC entry 3103 (class 0 OID 16505)
-- Dependencies: 213
-- Data for Name: User; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."User" ("JobTitle", "UserTitle", "PartyId", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "UserName", "IdentityProviderId", "Id") FROM stdin;
string	1	1	1	1	2021-01-29 18:08:31.332588	2021-01-29 18:08:31.332602	f	\N	string	1	1
Mr	1	13	13	13	2021-02-01 16:15:20.895514	2021-02-01 16:15:20.895522	f	\N	lee.pavlou3@gmail.com	1	6
Mr	1	16	16	16	2021-02-01 16:28:03.660092	2021-02-01 16:28:03.660098	f	\N	lee.pavlou4@gmail.com	1	7
Mr	1	20	20	20	2021-02-01 16:43:48.023318	2021-02-01 16:43:48.023326	f	\N	lee.pavlou5@gmail.com	1	8
Mr	1	24	24	24	2021-02-01 16:44:17.006276	2021-02-01 16:44:17.006282	f	\N	lee.pavlou6@gmail.com	1	9
Mr	1	28	28	28	2021-02-01 16:50:07.864107	2021-02-01 16:50:07.864116	f	\N	lee.pavlou7@gmail.com	1	10
Mr	1	32	32	32	2021-02-01 17:05:19.674699	2021-02-01 17:05:19.674723	f	\N	lee.pavlou9@gmail.com	1	11
Mr	1	36	36	36	2021-02-01 17:26:39.440047	2021-02-01 17:26:39.440049	f	\N	lee.pavlou10@gmail.com	1	12
Mr	1	40	40	40	2021-02-01 17:32:52.219325	2021-02-01 17:32:52.219326	f	\N	lee.pavlou11@gmail.com	1	13
Mr	1	69	69	69	2021-02-02 15:46:09.602348	2021-02-02 15:46:09.602355	f	\N	lee.pavlou22@googlemail.com	1	71
Mr	1	2	1	1	2021-02-01 15:50:08.753056	2021-02-01 15:50:08.753151	f	\N	lee.pavlou35@gmail.com	1	5
Mr	1	74	74	74	2021-02-02 15:49:06.411611	2021-02-02 15:49:06.411613	f	\N	lee.pavlou82@gmail.com	1	76
Mr	1	79	79	79	2021-02-02 16:53:48.145309	2021-02-02 16:53:48.145312	f	\N	lee.pavlou2@brickendon.com	1	81
Mr	1	84	84	84	2021-02-02 17:35:34.779637	2021-02-02 17:35:34.779641	f	\N	murugesh.mj@brickendon.com	1	86
Mr	1	89	89	89	2021-02-02 18:06:26.486399	2021-02-02 18:06:26.486402	f	\N	lee.pavlou0@googlemail.com	1	91
\.


--
-- TOC entry 3114 (class 0 OID 16695)
-- Dependencies: 224
-- Data for Name: UserAccessRole; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."UserAccessRole" ("UserId", "CcsAccessRoleId", "OrganisationAccessRoleId", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "Id") FROM stdin;
\.


--
-- TOC entry 3110 (class 0 OID 16625)
-- Dependencies: 220
-- Data for Name: UserGroup; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."UserGroup" ("OrganisationId", "UserGroupName", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "Id") FROM stdin;
\.


--
-- TOC entry 3115 (class 0 OID 16720)
-- Dependencies: 225
-- Data for Name: UserGroupMembership; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."UserGroupMembership" ("UserGroupId", "UserId", "MembershipStartDate", "MembershipEndDate", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "Id") FROM stdin;
\.


--
-- TOC entry 3111 (class 0 OID 16640)
-- Dependencies: 221
-- Data for Name: UserSetting; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."UserSetting" ("UserId", "UserSettingTypeId", "UserSettingValue", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "Id") FROM stdin;
\.


--
-- TOC entry 3098 (class 0 OID 16440)
-- Dependencies: 208
-- Data for Name: UserSettingType; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."UserSettingType" ("UserSettingName", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "Id") FROM stdin;
\.


--
-- TOC entry 3113 (class 0 OID 16675)
-- Dependencies: 223
-- Data for Name: VirtualAddress; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."VirtualAddress" ("VirtualAddressValue", "VirtualAddressTypeId", "ContactDetailId", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "Id") FROM stdin;
lee.pavlou@gmail.com	1	95	0	0	2021-02-03 11:31:51.031194	2021-02-03 11:31:51.031194	f	\N	96
07815750229	3	95	0	0	2021-02-03 11:31:51.031198	2021-02-03 11:31:51.031198	f	\N	97
testuser@xxx.com	1	111	0	0	2021-02-03 11:58:09.655324	2021-02-03 11:58:09.655324	f	\N	113
0123456789	3	111	0	0	2021-02-03 11:58:09.655326	2021-02-03 11:58:09.655326	f	\N	114
12345678	4	202	0	0	2021-02-05 14:38:28.882598	2021-02-05 14:38:28.882598	f	\N	204
02082031234	3	202	0	0	2021-02-05 14:38:28.882607	2021-02-05 14:38:28.882607	f	\N	205
www.bing.com	2	202	0	0	2021-02-05 14:38:28.882611	2021-02-05 14:38:28.882611	f	\N	206
12345678	4	210	0	0	2021-02-05 14:51:48.668797	2021-02-05 14:51:48.668797	f	\N	212
02082031234	3	210	0	0	2021-02-05 14:51:48.668802	2021-02-05 14:51:48.668802	f	\N	213
www.bing.com	2	210	0	0	2021-02-05 14:51:48.668805	2021-02-05 14:51:48.668805	f	\N	214
\N	4	218	0	0	2021-02-05 16:01:06.833891	2021-02-05 16:01:06.833891	f	\N	220
\N	3	218	0	0	2021-02-05 16:01:06.833902	2021-02-05 16:01:06.833902	f	\N	221
\N	2	218	0	0	2021-02-05 16:01:06.833907	2021-02-05 16:01:06.833907	f	\N	222
\.


--
-- TOC entry 3099 (class 0 OID 16450)
-- Dependencies: 209
-- Data for Name: VirtualAddressType; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."VirtualAddressType" ("Name", "Description", "CreatedPartyId", "LastUpdatedPartyId", "CreatedOnUtc", "LastUpdatedOnUtc", "IsDeleted", "ConcurrencyKey", "Id") FROM stdin;
EMAIL	Email	0	0	2021-01-28 16:57:34.732024	2021-01-28 16:57:34.732024	f	\N	1
WEB_ADDRESS	Web Address	0	0	2021-01-28 16:57:34.732024	2021-01-28 16:57:34.732024	f	\N	2
PHONE	Phone	0	0	2021-01-28 16:57:34.732024	2021-01-28 16:57:34.732024	f	\N	3
FAX	Fax	0	0	2021-01-28 16:57:34.732024	2021-01-28 16:57:34.732024	f	\N	4
\.


--
-- TOC entry 3093 (class 0 OID 16393)
-- Dependencies: 203
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20210119142331_InitialMigration	5.0.2
20210202062318_AddContactPointReason	5.0.2
20210203064222_AddLegalNameToOrganisation	5.0.2
\.


--
-- TOC entry 3169 (class 0 OID 0)
-- Dependencies: 243
-- Name: CcsAccessRole_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."CcsAccessRole_Id_seq"', 1, false);


--
-- TOC entry 3170 (class 0 OID 0)
-- Dependencies: 232
-- Name: ContactDetail_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."ContactDetail_Id_seq"', 1, false);


--
-- TOC entry 3171 (class 0 OID 0)
-- Dependencies: 249
-- Name: ContactPointReason_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."ContactPointReason_Id_seq"', 7, true);


--
-- TOC entry 3172 (class 0 OID 0)
-- Dependencies: 231
-- Name: ContactPoint_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."ContactPoint_Id_seq"', 1, false);


--
-- TOC entry 3173 (class 0 OID 0)
-- Dependencies: 246
-- Name: EnterpriseType_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."EnterpriseType_Id_seq"', 1, false);


--
-- TOC entry 3174 (class 0 OID 0)
-- Dependencies: 227
-- Name: IdentityProvider_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."IdentityProvider_Id_seq"', 3, true);


--
-- TOC entry 3175 (class 0 OID 0)
-- Dependencies: 247
-- Name: OrganisationAccessRole_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."OrganisationAccessRole_Id_seq"', 1, false);


--
-- TOC entry 3176 (class 0 OID 0)
-- Dependencies: 245
-- Name: OrganisationEnterpriseType_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."OrganisationEnterpriseType_Id_seq"', 1, false);


--
-- TOC entry 3177 (class 0 OID 0)
-- Dependencies: 235
-- Name: Organisation_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Organisation_Id_seq"', 1, true);


--
-- TOC entry 3178 (class 0 OID 0)
-- Dependencies: 248
-- Name: PartyType_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."PartyType_Id_seq"', 4, true);


--
-- TOC entry 3179 (class 0 OID 0)
-- Dependencies: 229
-- Name: Party_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Party_Id_seq"', 3, true);


--
-- TOC entry 3180 (class 0 OID 0)
-- Dependencies: 230
-- Name: Person_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Person_Id_seq"', 1, false);


--
-- TOC entry 3181 (class 0 OID 0)
-- Dependencies: 233
-- Name: PhysicalAddress_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."PhysicalAddress_Id_seq"', 1, false);


--
-- TOC entry 3182 (class 0 OID 0)
-- Dependencies: 236
-- Name: ProcurementGroup_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."ProcurementGroup_Id_seq"', 1, false);


--
-- TOC entry 3183 (class 0 OID 0)
-- Dependencies: 237
-- Name: TradingOrganisation_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."TradingOrganisation_Id_seq"', 1, false);


--
-- TOC entry 3184 (class 0 OID 0)
-- Dependencies: 241
-- Name: UserAccessRole_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."UserAccessRole_Id_seq"', 1, false);


--
-- TOC entry 3185 (class 0 OID 0)
-- Dependencies: 238
-- Name: UserGroupMembership_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."UserGroupMembership_Id_seq"', 1, false);


--
-- TOC entry 3186 (class 0 OID 0)
-- Dependencies: 239
-- Name: UserGroup_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."UserGroup_Id_seq"', 1, false);


--
-- TOC entry 3187 (class 0 OID 0)
-- Dependencies: 242
-- Name: UserSettingType_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."UserSettingType_Id_seq"', 1, false);


--
-- TOC entry 3188 (class 0 OID 0)
-- Dependencies: 240
-- Name: UserSetting_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."UserSetting_Id_seq"', 1, false);


--
-- TOC entry 3189 (class 0 OID 0)
-- Dependencies: 228
-- Name: User_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."User_Id_seq"', 13, true);


--
-- TOC entry 3190 (class 0 OID 0)
-- Dependencies: 244
-- Name: VirtualAddressType_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."VirtualAddressType_Id_seq"', 4, true);


--
-- TOC entry 3191 (class 0 OID 0)
-- Dependencies: 234
-- Name: VirtualAddress_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."VirtualAddress_Id_seq"', 1, false);


--
-- TOC entry 3192 (class 0 OID 0)
-- Dependencies: 226
-- Name: postgres_increment_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.postgres_increment_seq', 223, true);


--
-- TOC entry 2875 (class 2606 OID 17262)
-- Name: CcsAccessRole CcsAccessRole_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."CcsAccessRole"
    ADD CONSTRAINT "CcsAccessRole_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2900 (class 2606 OID 17052)
-- Name: ContactDetail ContactDetail_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ContactDetail"
    ADD CONSTRAINT "ContactDetail_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2890 (class 2606 OID 17033)
-- Name: ContactPoint ContactPoint_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ContactPoint"
    ADD CONSTRAINT "ContactPoint_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2877 (class 2606 OID 17314)
-- Name: EnterpriseType EnterpriseType_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."EnterpriseType"
    ADD CONSTRAINT "EnterpriseType_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2879 (class 2606 OID 16937)
-- Name: IdentityProvider IdentityProvider_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."IdentityProvider"
    ADD CONSTRAINT "IdentityProvider_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2904 (class 2606 OID 17332)
-- Name: OrganisationAccessRole OrganisationAccessRole_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."OrganisationAccessRole"
    ADD CONSTRAINT "OrganisationAccessRole_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2908 (class 2606 OID 17298)
-- Name: OrganisationEnterpriseType OrganisationEnterpriseType_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."OrganisationEnterpriseType"
    ADD CONSTRAINT "OrganisationEnterpriseType_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2895 (class 2606 OID 17106)
-- Name: Organisation Organisation_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Organisation"
    ADD CONSTRAINT "Organisation_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2943 (class 2606 OID 24600)
-- Name: ContactPointReason PK_ContactPointReason; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ContactPointReason"
    ADD CONSTRAINT "PK_ContactPointReason" PRIMARY KEY ("Id");


--
-- TOC entry 2873 (class 2606 OID 16397)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- TOC entry 2881 (class 2606 OID 17351)
-- Name: PartyType PartyType_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PartyType"
    ADD CONSTRAINT "PartyType_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2888 (class 2606 OID 16984)
-- Name: Party Party_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Party"
    ADD CONSTRAINT "Party_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2912 (class 2606 OID 17018)
-- Name: Person Person_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Person"
    ADD CONSTRAINT "Person_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2928 (class 2606 OID 17067)
-- Name: PhysicalAddress PhysicalAddress_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicalAddress"
    ADD CONSTRAINT "PhysicalAddress_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2915 (class 2606 OID 17150)
-- Name: ProcurementGroup ProcurementGroup_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ProcurementGroup"
    ADD CONSTRAINT "ProcurementGroup_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2918 (class 2606 OID 17164)
-- Name: TradingOrganisation TradingOrganisation_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TradingOrganisation"
    ADD CONSTRAINT "TradingOrganisation_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2937 (class 2606 OID 17228)
-- Name: UserAccessRole UserAccessRole_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserAccessRole"
    ADD CONSTRAINT "UserAccessRole_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2941 (class 2606 OID 17178)
-- Name: UserGroupMembership UserGroupMembership_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserGroupMembership"
    ADD CONSTRAINT "UserGroupMembership_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2921 (class 2606 OID 17192)
-- Name: UserGroup UserGroup_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserGroup"
    ADD CONSTRAINT "UserGroup_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2883 (class 2606 OID 17244)
-- Name: UserSettingType UserSettingType_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserSettingType"
    ADD CONSTRAINT "UserSettingType_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2925 (class 2606 OID 17213)
-- Name: UserSetting UserSetting_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserSetting"
    ADD CONSTRAINT "UserSetting_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2898 (class 2606 OID 16956)
-- Name: User User_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2885 (class 2606 OID 17280)
-- Name: VirtualAddressType VirtualAddressType_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."VirtualAddressType"
    ADD CONSTRAINT "VirtualAddressType_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2932 (class 2606 OID 17080)
-- Name: VirtualAddress VirtualAddress_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."VirtualAddress"
    ADD CONSTRAINT "VirtualAddress_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2901 (class 1259 OID 16738)
-- Name: IX_ContactDetail_ContactPointId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_ContactDetail_ContactPointId" ON public."ContactDetail" USING btree ("ContactPointId");


--
-- TOC entry 2891 (class 1259 OID 24602)
-- Name: IX_ContactPoint_ContactPointReasonId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_ContactPoint_ContactPointReasonId" ON public."ContactPoint" USING btree ("ContactPointReasonId");


--
-- TOC entry 2892 (class 1259 OID 16739)
-- Name: IX_ContactPoint_PartyId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_ContactPoint_PartyId" ON public."ContactPoint" USING btree ("PartyId");


--
-- TOC entry 2902 (class 1259 OID 16741)
-- Name: IX_OrganisationAccessRole_OrganisationId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_OrganisationAccessRole_OrganisationId" ON public."OrganisationAccessRole" USING btree ("OrganisationId");


--
-- TOC entry 2905 (class 1259 OID 16742)
-- Name: IX_OrganisationEnterpriseType_EnterpriseTypeId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_OrganisationEnterpriseType_EnterpriseTypeId" ON public."OrganisationEnterpriseType" USING btree ("EnterpriseTypeId");


--
-- TOC entry 2906 (class 1259 OID 16743)
-- Name: IX_OrganisationEnterpriseType_OrganisationId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_OrganisationEnterpriseType_OrganisationId" ON public."OrganisationEnterpriseType" USING btree ("OrganisationId");


--
-- TOC entry 2893 (class 1259 OID 16740)
-- Name: IX_Organisation_PartyId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_Organisation_PartyId" ON public."Organisation" USING btree ("PartyId");


--
-- TOC entry 2886 (class 1259 OID 16744)
-- Name: IX_Party_PartyTypeId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Party_PartyTypeId" ON public."Party" USING btree ("PartyTypeId");


--
-- TOC entry 2909 (class 1259 OID 16745)
-- Name: IX_Person_OrganisationId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Person_OrganisationId" ON public."Person" USING btree ("OrganisationId");


--
-- TOC entry 2910 (class 1259 OID 16746)
-- Name: IX_Person_PartyId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_Person_PartyId" ON public."Person" USING btree ("PartyId");


--
-- TOC entry 2926 (class 1259 OID 16747)
-- Name: IX_PhysicalAddress_ContactDetailId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_PhysicalAddress_ContactDetailId" ON public."PhysicalAddress" USING btree ("ContactDetailId");


--
-- TOC entry 2913 (class 1259 OID 16748)
-- Name: IX_ProcurementGroup_OrganisationId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_ProcurementGroup_OrganisationId" ON public."ProcurementGroup" USING btree ("OrganisationId");


--
-- TOC entry 2916 (class 1259 OID 16749)
-- Name: IX_TradingOrganisation_OrganisationId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_TradingOrganisation_OrganisationId" ON public."TradingOrganisation" USING btree ("OrganisationId");


--
-- TOC entry 2933 (class 1259 OID 16752)
-- Name: IX_UserAccessRole_CcsAccessRoleId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_UserAccessRole_CcsAccessRoleId" ON public."UserAccessRole" USING btree ("CcsAccessRoleId");


--
-- TOC entry 2934 (class 1259 OID 16753)
-- Name: IX_UserAccessRole_OrganisationAccessRoleId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_UserAccessRole_OrganisationAccessRoleId" ON public."UserAccessRole" USING btree ("OrganisationAccessRoleId");


--
-- TOC entry 2935 (class 1259 OID 16754)
-- Name: IX_UserAccessRole_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_UserAccessRole_UserId" ON public."UserAccessRole" USING btree ("UserId");


--
-- TOC entry 2938 (class 1259 OID 16756)
-- Name: IX_UserGroupMembership_UserGroupId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_UserGroupMembership_UserGroupId" ON public."UserGroupMembership" USING btree ("UserGroupId");


--
-- TOC entry 2939 (class 1259 OID 16757)
-- Name: IX_UserGroupMembership_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_UserGroupMembership_UserId" ON public."UserGroupMembership" USING btree ("UserId");


--
-- TOC entry 2919 (class 1259 OID 16755)
-- Name: IX_UserGroup_OrganisationId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_UserGroup_OrganisationId" ON public."UserGroup" USING btree ("OrganisationId");


--
-- TOC entry 2922 (class 1259 OID 16758)
-- Name: IX_UserSetting_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_UserSetting_UserId" ON public."UserSetting" USING btree ("UserId");


--
-- TOC entry 2923 (class 1259 OID 16759)
-- Name: IX_UserSetting_UserSettingTypeId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_UserSetting_UserSettingTypeId" ON public."UserSetting" USING btree ("UserSettingTypeId");


--
-- TOC entry 2896 (class 1259 OID 16751)
-- Name: IX_User_PartyId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_User_PartyId" ON public."User" USING btree ("PartyId");


--
-- TOC entry 2929 (class 1259 OID 16760)
-- Name: IX_VirtualAddress_ContactDetailId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_VirtualAddress_ContactDetailId" ON public."VirtualAddress" USING btree ("ContactDetailId");


--
-- TOC entry 2930 (class 1259 OID 16761)
-- Name: IX_VirtualAddress_VirtualAddressTypeId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_VirtualAddress_VirtualAddressTypeId" ON public."VirtualAddress" USING btree ("VirtualAddressTypeId");


--
-- TOC entry 2948 (class 2606 OID 17043)
-- Name: ContactDetail FK_ContactDetails_ContactPoint_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ContactDetail"
    ADD CONSTRAINT "FK_ContactDetails_ContactPoint_Id" FOREIGN KEY ("ContactPointId") REFERENCES public."ContactPoint"("Id");


--
-- TOC entry 2945 (class 2606 OID 17009)
-- Name: ContactPoint FK_ContactPoint_Party_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ContactPoint"
    ADD CONSTRAINT "FK_ContactPoint_Party_Id" FOREIGN KEY ("PartyId") REFERENCES public."Party"("Id");


--
-- TOC entry 2949 (class 2606 OID 17116)
-- Name: OrganisationAccessRole FK_OrganisationAccessRole_Organisation_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."OrganisationAccessRole"
    ADD CONSTRAINT "FK_OrganisationAccessRole_Organisation_Id" FOREIGN KEY ("OrganisationId") REFERENCES public."Organisation"("Id");


--
-- TOC entry 2951 (class 2606 OID 17323)
-- Name: OrganisationEnterpriseType FK_OrganisationEnterpriseType_EnterpriseType_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."OrganisationEnterpriseType"
    ADD CONSTRAINT "FK_OrganisationEnterpriseType_EnterpriseType_Id" FOREIGN KEY ("EnterpriseTypeId") REFERENCES public."EnterpriseType"("Id");


--
-- TOC entry 2950 (class 2606 OID 17121)
-- Name: OrganisationEnterpriseType FK_OrganisationEnterpriseType_Organisation_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."OrganisationEnterpriseType"
    ADD CONSTRAINT "FK_OrganisationEnterpriseType_Organisation_Id" FOREIGN KEY ("OrganisationId") REFERENCES public."Organisation"("Id");


--
-- TOC entry 2946 (class 2606 OID 17004)
-- Name: Organisation FK_Organisation_Party_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Organisation"
    ADD CONSTRAINT "FK_Organisation_Party_Id" FOREIGN KEY ("PartyId") REFERENCES public."Party"("Id");


--
-- TOC entry 2944 (class 2606 OID 17360)
-- Name: Party FK_Party_PartyType_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Party"
    ADD CONSTRAINT "FK_Party_PartyType_Id" FOREIGN KEY ("PartyTypeId") REFERENCES public."PartyType"("Id");


--
-- TOC entry 2953 (class 2606 OID 17126)
-- Name: Person FK_Person_Organisation_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Person"
    ADD CONSTRAINT "FK_Person_Organisation_Id" FOREIGN KEY ("OrganisationId") REFERENCES public."Organisation"("Id");


--
-- TOC entry 2952 (class 2606 OID 16994)
-- Name: Person FK_Person_Party_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Person"
    ADD CONSTRAINT "FK_Person_Party_Id" FOREIGN KEY ("PartyId") REFERENCES public."Party"("Id");


--
-- TOC entry 2959 (class 2606 OID 17097)
-- Name: PhysicalAddress FK_PhysicalAddress_ContactDetail_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicalAddress"
    ADD CONSTRAINT "FK_PhysicalAddress_ContactDetail_Id" FOREIGN KEY ("ContactDetailId") REFERENCES public."ContactDetail"("Id");


--
-- TOC entry 2954 (class 2606 OID 17131)
-- Name: ProcurementGroup FK_ProcurementGroup_Organisation_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ProcurementGroup"
    ADD CONSTRAINT "FK_ProcurementGroup_Organisation_Id" FOREIGN KEY ("OrganisationId") REFERENCES public."Organisation"("Id");


--
-- TOC entry 2955 (class 2606 OID 17136)
-- Name: TradingOrganisation FK_TradingOrganisation_Organisation_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TradingOrganisation"
    ADD CONSTRAINT "FK_TradingOrganisation_Organisation_Id" FOREIGN KEY ("OrganisationId") REFERENCES public."Organisation"("Id");


--
-- TOC entry 2963 (class 2606 OID 17271)
-- Name: UserAccessRole FK_UserAccessRole_CcsAccessRole_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserAccessRole"
    ADD CONSTRAINT "FK_UserAccessRole_CcsAccessRole_Id" FOREIGN KEY ("CcsAccessRoleId") REFERENCES public."CcsAccessRole"("Id");


--
-- TOC entry 2964 (class 2606 OID 17342)
-- Name: UserAccessRole FK_UserAccessRole_OrganisationAccessRole_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserAccessRole"
    ADD CONSTRAINT "FK_UserAccessRole_OrganisationAccessRole_Id" FOREIGN KEY ("OrganisationAccessRoleId") REFERENCES public."OrganisationAccessRole"("Id");


--
-- TOC entry 2962 (class 2606 OID 16965)
-- Name: UserAccessRole FK_UserAccessRole_User_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserAccessRole"
    ADD CONSTRAINT "FK_UserAccessRole_User_Id" FOREIGN KEY ("UserId") REFERENCES public."User"("Id");


--
-- TOC entry 2966 (class 2606 OID 17204)
-- Name: UserGroupMembership FK_UserGroupMembership_UserGroup_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserGroupMembership"
    ADD CONSTRAINT "FK_UserGroupMembership_UserGroup_Id" FOREIGN KEY ("UserGroupId") REFERENCES public."UserGroup"("Id");


--
-- TOC entry 2965 (class 2606 OID 16970)
-- Name: UserGroupMembership FK_UserGroupMembership_User_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserGroupMembership"
    ADD CONSTRAINT "FK_UserGroupMembership_User_Id" FOREIGN KEY ("UserId") REFERENCES public."User"("Id");


--
-- TOC entry 2956 (class 2606 OID 17141)
-- Name: UserGroup FK_UserGroup_Organisation_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserGroup"
    ADD CONSTRAINT "FK_UserGroup_Organisation_Id" FOREIGN KEY ("OrganisationId") REFERENCES public."Organisation"("Id");


--
-- TOC entry 2958 (class 2606 OID 17253)
-- Name: UserSetting FK_UserSetting_UserSettingType_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserSetting"
    ADD CONSTRAINT "FK_UserSetting_UserSettingType_Id" FOREIGN KEY ("UserSettingTypeId") REFERENCES public."UserSettingType"("Id");


--
-- TOC entry 2957 (class 2606 OID 16975)
-- Name: UserSetting FK_UserSetting_User_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserSetting"
    ADD CONSTRAINT "FK_UserSetting_User_Id" FOREIGN KEY ("UserId") REFERENCES public."User"("Id");


--
-- TOC entry 2947 (class 2606 OID 16999)
-- Name: User FK_User_Party_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "FK_User_Party_Id" FOREIGN KEY ("PartyId") REFERENCES public."Party"("Id");


--
-- TOC entry 2960 (class 2606 OID 17092)
-- Name: VirtualAddress FK_VirtualAddress_ContactDetail_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."VirtualAddress"
    ADD CONSTRAINT "FK_VirtualAddress_ContactDetail_Id" FOREIGN KEY ("ContactDetailId") REFERENCES public."ContactDetail"("Id");


--
-- TOC entry 2961 (class 2606 OID 17289)
-- Name: VirtualAddress FK_VirtualAddress_VirtualAddressType_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."VirtualAddress"
    ADD CONSTRAINT "FK_VirtualAddress_VirtualAddressType_Id" FOREIGN KEY ("VirtualAddressTypeId") REFERENCES public."VirtualAddressType"("Id");


-- Completed on 2021-02-05 16:24:20

--
-- PostgreSQL database dump complete
--

