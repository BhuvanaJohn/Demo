Feature: SwordActiveRisk_BlogVerification

Background:

Given User is at "blog" page of SwordActiveRisk portal 

Scenario Outline: Validate the correct number of blog posts are shown for each blog post by date

When the user is on the Active Risk Blog Page
Then the Blog posts By Date are displayed 
When the user clicks on Blog post by date '<BlogByDate>'
Then the active risk blog opens in a new tab 
And the list of articles are present in The Active Risk Blog
And the Number of Blogs posted match the referenced numbers '<NumberOfArticles>'
And the user is on Active Risk Blog homepage

Examples: 
| BlogByDate     | NumberOfArticles |
| February 2017  | 2                |
| January 2017   | 5                |
| December 2016  | 1                |
| November 2016  | 1                |
| October 2016   | 1                |
| September 2016 | 1                |
| August 2016    | 1                |
| July 2016      | 3                |
| June 2016      | 1                |
| March 2016     | 1                |
| January 2016   | 1                |
| November 2015  | 1                |
| October 2015   | 2                |
| September 2015 | 5                |
| August 2015    | 1                |
| July 2015      | 3                |
| April 2015     | 1                |
| March 2015     | 3                |
| February 2015  | 1                |
| December 2014  | 1                |
| October 2014   | 1                |
| September 2014 | 1                |
| August 2014    | 1                |
| April 2014     | 2                |
| March 2014     | 2                |
| February 2014  | 1                |
| August 2013    | 3                |
| July 2013      | 5                |
| June 2013      | 1                |
| April 2013     | 5                |
| March 2013     | 6                |
| February 2013  | 8                |
| January 2013   | 4                |
| December 2012  | 2                |
| November 2012  | 2                |
| October 2012   | 6                |
| September 2012 | 6                |
| August 2012    | 7                |
| July 2012      | 4                |
| June 2012      | 2                |
| May 2012       | 1                |
| April 2012     | 2                |
| March 2012     | 8                |
| February 2012  | 4                |
| January 2012   | 6                |
| December 2011  | 7                |