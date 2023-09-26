from PIL import Image


class ImageViewer():
    def __init__(self, imagePath):
        self.image = Image.open(imagePath)

    def view(self):
        self.image.show()
