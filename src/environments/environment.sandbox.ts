declare var process : {
  env: {
    CII_TOKEN: string
  }
}

export const environment = {
  production: true,
  uri: {
    api: {
      security: 'https://sand-api-security.london.cloudapps.digital',
      postgres: 'https://sand-api-core.london.cloudapps.digital',
      cii: 'https://conclave-cii-testing-talkative-oryx-hh.london.cloudapps.digital'
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
