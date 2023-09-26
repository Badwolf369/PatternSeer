import sys
from imageViewer import ImageViewer


def main(imagePath):
    display = ImageViewer(imagePath)
    display.view()


if __name__ == "__main__":
    if len(sys.argv) < 2:
        print("Error: please input a path to an image")
        exit()
    main(sys.argv[1])
