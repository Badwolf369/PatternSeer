from PIL import Image


class ImageViewer():
    def __init__(self, image):
        self.image = image

    def view(self):
        self.image.show()
