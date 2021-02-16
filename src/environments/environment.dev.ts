declare var process : {
  env: {
    CII_TOKEN: string
  }
}

export const environment = {
  production: true,
  uri: {
    api: {
      security: 'https://dev-api-security.london.cloudapps.digital',
      postgres: 'https://dev-api-core.london.cloudapps.digital',
      cii: 'https://conclave-cii-integration-brash-shark-mk.london.cloudapps.digital'
    },
    web: {
      dashboard: 'https://dev-ccs-sso.london.cloudapps.digital'
    }
  },
  token: {
    api: {
      cii: process.env.CII_TOKEN
    }
  }
};
