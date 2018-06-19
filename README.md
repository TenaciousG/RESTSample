Sample hosting & consuming implementation of RESTful Service using ASP.NET Web API.


Based on: http://www.patrickschadler.com/creating-a-rest-webservice-with-net-core/

Using folder-publish for hosting in IIS windows 10/7.

Sample uris:
http://localhost:8093/api/person //Get()
http://localhost:8093/api/person/4  //Get(int id)
http://localhost:8093/api/person  //Post([FromBody]string value)