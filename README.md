# MVC IDENTITY

insted of application.json, secrets.json is used like this

```json
{
  "ConnectionStrings": {
    "Default": "<sqlserver connection string>"
  }
}
"MailJet": {
    "ApiKey": "<public api key>",
    "SecretKey": "<Seceret api key>"
  }
```

note: mailjet needs to be version 1.2.2