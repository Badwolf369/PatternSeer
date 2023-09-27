import sys
from pdfViewer import PdfViewer
import pypdfium2 as pdfium


def main(pdfPath, pageNumber):
    viewport = PdfViewer(pdfPath)
    viewport.show(pageNumber)


if __name__ == "__main__":
    syntax = "Syntax: python main.py <pdfPath> (<pageNumber>)"
    if len(sys.argv) < 2:
        print("Error: Too few arguments")
        print(syntax)
        exit()
    elif len(sys.argv) == 2:
        main(sys.argv[1], 0)
    elif len(sys.argv) == 3:
        try:
            main(sys.argv[1], int(sys.argv[2]))
        except ValueError:
            print("Error: <pagenumber> must be an integer")
            print(syntax)
    elif len(sys.argv) > 3:
        print("Error: Too many arguments entered")
        print(syntax)
