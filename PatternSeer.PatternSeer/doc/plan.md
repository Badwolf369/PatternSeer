# Window Setup

- Configure the window to use for the UI
    - Toolbar at the top of the screen
        - Button to open a new pdf file
    - Preview pane to render the pdf pages
        - Scrolling should be enabled when hovering over this pane. Also CTRL+Scroll and CTRL++/CTRL+- should control zoom.
        - There should be a scroll bar with a thing next to it that displays what page you are on when you change pages
        - Pdf pages are to display information about the chart such as areas that have been autodetected or manually input as being relevent
        - If no PDF is loaded then display a message asking to import a pdf
    - Footer
        - status message
        - name of current pdf file open
        - current pagenumber
- Open the window

# Opening a PDF

- Import pdf pages as images
    - Validate the pdf path provided and throw an error if it is invalid
    - Rasterize PDF and save into a memory stream
    - Decode images from the data in the memory stream

# Depricated for now

- Create the Chart from the images
    - Guess which images contain chart data about the pattern layout
        - Add a confidence score to each guess
        - If no confidence score is able to meet a certain minimum threshold, alert the user and ask to enter manual mode for this step
        - If the number of guessed images does not create a grid, alert the user and ask to enter manual mode for this step
            Several patterns do not create a perfect grid of pages, my advent calendar for example. We must find an alternative method for stitching pages together
    - Guess which images contain data about the chart key
        - Add a confidence score to each guess
        - Choose the image that has the highest confidence score. If no image has a sufficiently high score, alert the user and ask to enter manual mode for this step
    - Use OCR to locate all blurbs of text in each of the images
    - Create a confidence score for each blurb based on location and content in order to guess general chart info such as stitched area, fabric info, copyright info, artist, title, etc.
