#!/bin/bash
curl -i http://localhost:5215/graphql \
  -F operations='{ "query": "mutation ($file: Upload!) { testMutation(input: {file: $file}) }", "variables": { "file": null } }' \
  -F map='{ "0": ["variables.file"] }' \
  -F 0=@test.txt