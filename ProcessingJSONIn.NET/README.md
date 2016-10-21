## Processing JSON in .NET
### _Homework_

*   Using JSON.NET and the Telerik Academy Youtube RSS feed, implement the following:

    1.    The RSS feed is located at https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw
    2.    Download the content of the feed programatically
        *   You can use `WebClient.DownloadFile()`
    3.    Parse the XML from the feed to JSON
    4.    Using LINQ-to-JSON select all video titles and print them on the console
    5.    Parse the videos' JSON to POCO
    6.    Using the POCOs create a HTML page that shows all videos from the RSS
        *   Use `<iframe>`
        *   Provide links, that navigate to their videos in YouTube 
    
