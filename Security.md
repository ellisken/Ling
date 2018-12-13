# Security and Performance Analysis

This document details the Security and Performance analysis for the Ling web application.

## Overview

Ling Web Application allows for anonymous access, and does not support authentication schemes. The deployment of the application uses HTTPs, and accesses Blob storage with a global CORS configuration.

Azure Blob storage is used as a backend file storage for audio files. The file upload path is as follows:

Browser -> Web Server -> Blob Storage

As such there is a performance limitation as it relates to the web server and Blob Storage performance.

## Sensitive data exposure
Sensitive data exposure is the use/manipulation of data which is not secure. Such case is when data that is sensitive lacks encryption, or when data is transmited unsecurely.

Sensitive data exposure could affect our users by exposing sensitive audio information related to their recording record. If we stored identifiable information with the recordings such as location data, we would be exposing sensitive user information to potential attackers.

Repair
Ensure we are using a TLS on our web site with a strong policy, and by not storing our files in a predictable/identifiable naming format. We could accomplish this by encrypting personal data and by generating random file names.

DON'T DO:

	public string Name {get; set;}


DO:

Modifying Address field in order Model:

`public string Name { get => Decrypt(secret);  set => Encrypt(secret, value);}`


## SQL Injection
Exposure
SQL Injection is when malicious code is inserted into strings. These strings contain SQL syntax terminating characters which allow the attacker to 'inject' additional SQL statements.

SQL Injection could allow a attacker to view data on our customers, or potentially place orders with a cost of $0.

DON'T DO:

`  string strQry = "SELECT * FROM Recordings WHERE ISOCode='" + code.Text + "'";
   EXEC strQry // SQL Injection vulnerability!
`

DO:

`  var sql = @"Update [User] SET ISOCode = @Code WHERE Id = @Id";
   context.Database.ExecuteSqlCommand(
      sql,
      new SqlParameter("@Code", code),
      new SqlParameter("@Id", id));`

Repair
Our website is secure against SQL injection because no user submitted information is stored on our database. Any data we store is first parsed and transformed, and it's output is then stored without the possibility for injection. 
