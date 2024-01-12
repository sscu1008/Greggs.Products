This demo library is set up to follow the CQRS pattern using MediatR. 
  
The List method has been moved from the original DataAccess in the Products.Api  to this library. 
The original Products.Api DataAccess and Models implementations have also been moved to this library. 
The original ProductController remains in place in Controllers to call the corresponding CQRS Handlers in this library. 
  

The CQRS pattern may seem excessive for this code example as it is more suited to larger applications and microservices 
as it allows for database actions to be implemented and scaled separately. 
  
Product Model:
I have added an additional PriceInEuros calculated field to work along side the existing 'PriceInPounds' field,
so any exisitng code / data using 'PriceInPounds' is not affected.

GetLatestProducts:
I would have asked a question to the Develoment Team about implementing a generic sort based on the url to allow for more than one search (e.g Name or date added or price etc).
Although this would be scope creep and is not requested in the work item, so I have opted to the 'Latest' sort directly.

Pagination: 
In the List procedure for the code supplied, the pagination is not wired correctly - pagination should start at page 1 and step in page sizes 
I would normally raise this with the team and fix in passing or raise a separate bug, 
as i am working directly on this code i would fix it in passing. 
  

AppSettings: 
I have added configuration options allow for exchange rate to be set outside of code (in appSettings.json) 
and eliminate the 'Magic Number'(no magic numbers) for setting the euro exchange rate. 
  

Testing: 
I have added a few basic tests using xUnit.

 

 