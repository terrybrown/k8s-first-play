

##Setting up Redis in a container

Run the docker container with redis in it.

`docker run --name k8s-first-play-redis -p 6379:6379 -d redis`

(if you already run redis locally, you will need to expose it under a different port)

Ensure you can connect to it:
- Via commandline: `redis-cli`
- Via docker: `docker run -it --link k8s-first-play-redis:redis --rm redis redis-cli -h redis -p 6379`

If you feel you want to validate the above two connections are the same just run `set test 1` in one, ensure you can `get test` in it before exiting, then connect to the other and run `get test` - you should find the value there as it's the same running instance of redis.

##Running the App

Startup the app with `dotnet run`, and you can hit:
`https://localhost:5001/api/redis` with an HTTP GET.

To see values coming through, run the following on the command line:

`while true; do curl --insecure -d '{}' -H "Content-Type: application/json" -X POST https://localhost:5001/api/redis; sleep 1; done`

This will fire off POST requests to thew endpoint, which should allow you to see the key incrementing at the GET endpoint above.

To reset the value in redis, run:

`curl --insecure -X DELETE https://localhost:5001/api/redis`