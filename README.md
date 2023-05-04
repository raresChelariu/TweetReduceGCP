# TweetReduceGCP 

## TweetReduce - Console App which aggregates tweets extracted with project [TwitterCandidatesScrapper](https://github.com/raresChelariu/TwitterCandidatesScrapper)

## Tweet GCP API - Web HTTP API which call GCP's Natural Language API to analyze sentiment and entities of text input. 

### Each endpoint receives a HTTP Query Parameter path which expects a url-encoded disk path of the server where the content to be analyzed is stored.

### Available endpoints: 

* GET /sentiment
  * Query parameters:
    * path - string - disk path of content file
* GET /entity
    * Query parameters:
      * path - string - disk path of content file
* GET /entitysentiment
    * Query parameters:
      * path - string - disk path of content file
