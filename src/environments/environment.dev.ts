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
      dashboard: 'http://localhost:4200'
    }
  },
  token: {
    api: {
      cii: process.env.CII_TOKEN
    }
  }
};
