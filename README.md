Sample hosting & consuming implementation of RESTful Service using ASP.NET Web API.


Based on: http://www.patrickschadler.com/creating-a-rest-webservice-with-net-core/

Using folder-publish for hosting in IIS windows 10/7.

Sample uris:
http://localhost:8093/api/person //Get()
http://localhost:8093/api/person/4  //Get(int id)
http://localhost:8093/api/person  //Post([FromBody]string value)


Rest GET Request:
GET /api/person HTTP/1.1
Host: gol-zb15:8093
Cache-Control: no-cache
Postman-Token: 615c7161-ad0d-4383-8659-ca132c1494e5



Rest POST Request:
POST /api/person HTTP/1.1
Host: localhost:8093
Content-Type: application/json
Cache-Control: no-cache
Postman-Token: 1f9e7f64-0403-43ff-9362-6a2eba488681

"test"