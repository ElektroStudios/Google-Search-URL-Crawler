# Google Search URL Crawler Change Log 📋

## v1.1 (2024) *(current)* 🆕

Note that it's been five years since the previous release, and Google had time to change the way it returns results with a clear intention of making it more difficult to programmatically process the returned html elements.

Therefore, this version may not work as excellent as it did in the year 2019; However, this version is functional and it seems to perform a good job.

#### 🛠️ Fixes:
    • The program stopped working due obsolescence.
    • "Search" button did not preserved allignment when the window gets resized.
#### 🌟 Improvements:
    • Source-code upgraded to .NET Framework 4.8
    • Internal Html parsing algorithm has been rewritten from scratch.
    • Added random interval delay between search queries to try prevent an IP ban.
    • Improved default user-agent string to try prevent getting banned due using a fake browser agent.
    • When selecting a row from the search results, the URL is displayed in the bottom textbox control of the window.
    • Basic status messages are displayed at the bottom of the circular progress bar.
    • Ensured format compatibility when exporting to CSV by replacing the default delimitter (;) in the CSV fields.

## v1.0 (2019) 🔄
Initial Release.