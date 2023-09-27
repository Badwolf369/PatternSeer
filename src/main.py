import sys
from imageViewer import ImageViewer
import pypdfium2 as pdfium


def main(pdfPath):
    document = pdfium.PdfDocument(pdfPath)
    for page in document:
        pageImage = page.render().to_pil()
        display = ImageViewer(pageImage)
        display.view()


if __name__ == "__main__":
    if len(sys.argv) < 2:
        print("Error: please give the path to a pdf file to work with")
        exit()
    main(sys.argv[1])
