declare var process : {
  env: {
    CII_TOKEN: string
  }
}
export const environment = {
  production: true,
  uri: {
    api: {
      security: 'https://ccs-sso-api-agile-ratel-ix.london.cloudapps.digital',
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
