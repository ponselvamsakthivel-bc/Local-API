declare var process : {
  env: {
    CII_TOKEN: string
  }
}

export const environment = {
  production: false,
  uri: {
    api: {
      // security: 'https://localhost:44352',
      security: 'https://ccs-sso-api-agile-ratel-ix.london.cloudapps.digital',
      // postgres: 'https://localhost:44330',
      postgres: 'https://api-org-22jan-proud-crane-wu.london.cloudapps.digital',
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