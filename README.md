This contains a minimum setup to reproduce a bug in file uploads in Hot Chocolate 13.2.0/13.2.1.

Step 1:
--
Start the webserver on port 5215
```sh
dotnet run --project hc-upload-bug
```

Step 2:
--
Execute the test script:
```sh
./test.sh
```

Validation:
--
On HC 13.2.0/13.2.1 the script returns `404 Not Found`.

When downgrading this same application to Hot Chocolate 13.1.0 it returns a `200 OK`.