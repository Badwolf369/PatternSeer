from PIL import Image
import pypdfium2 as pdfium


class PdfViewer():
    def __init__(self, pdfPath):
        self.pdf = pdfium.PdfDocument(pdfPath)

    def show(self, page):
        image = self.pdf[page].render().to_pil()
        image.show()
