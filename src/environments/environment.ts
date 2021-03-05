export const environment = {
  production: false,
  idam_client_id:'',
  uri: {
    api: {
      //security: 'https://localhost:44352',
      security: 'https://dev-api-security.london.cloudapps.digital',
      postgres: 'https://localhost:44330',
      // postgres: 'https://dev-api-core.london.cloudapps.digital',
      cii: 'https://conclave-cii-integration-brash-shark-mk.london.cloudapps.digital'
    },
    web: {
      dashboard: 'http://localhost:4200'
    }
  }
};
