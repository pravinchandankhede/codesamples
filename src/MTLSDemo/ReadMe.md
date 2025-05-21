
## Certificate Generation for Local Testing
We will utlize the Powershell command to generate a self-signed certificate for local testing. You can use OpenSSL or any other tool, but for simplicity, we will use the built-in command in Windows.

Generating certificates for local testing involve 3 steps:
1. Generate a self-signed certificate root certificate
2. Generate a self-signed certificate for the server
3. Generate a self-signed certificate for the client

### Step 1: Generate a self-signed root certificate

Run the below command in Powershell window

```powershell 
$rootCert = New-SelfSignedCertificate -Type Custom -KeyUsageProperty Sign -KeyUsage CertSign `
    -Subject "CN=MyRootCA" -KeyAlgorithm RSA -KeyLength 2048 -CertStoreLocation "Cert:\CurrentUser\My" `
    -NotAfter (Get-Date).AddYears(5) -FriendlyName "MyRootCA"
Export-Certificate -Cert $rootCert -FilePath .\rootCA.cer
```

### Step 2: Generate a self-signed server certificate

Run the below command in Powershell window

```powershell
$serverCert = New-SelfSignedCertificate -Type Custom -DnsName "localhost" `
    -KeyAlgorithm RSA -KeyLength 2048 -CertStoreLocation "Cert:\CurrentUser\My" `
    -Signer $rootCert -NotAfter (Get-Date).AddYears(2) -FriendlyName "BankingServiceServer"
Export-PfxCertificate -Cert $serverCert -FilePath .\server.pfx -Password (ConvertTo-SecureString -String "YourPassword123" -Force -AsPlainText)
```

### Step 3: Generate a self-signed client certificate

Run the below command in Powershell window

```powershell
$clientCert = New-SelfSignedCertificate -Type Custom -DnsName "client" `
    -KeyAlgorithm RSA -KeyLength 2048 -CertStoreLocation "Cert:\CurrentUser\My" `
    -Signer $rootCert -NotAfter (Get-Date).AddYears(2) -FriendlyName "BankingServiceClient"
Export-PfxCertificate -Cert $clientCert -FilePath .\client.pfx -Password (ConvertTo-SecureString -String "ClientPassword123" -Force -AsPlainText)
```

All these commands will generate the certificates in the current directory. You can change the path to save them in a different location. The `-Password` parameter is used to protect the PFX files with a password. Make sure to use a strong password and keep it secure.