@startuml
class Main {
    main()
}
class ImageViewer {
    image : Image
    init(self, image:Image)
    view()
}

main --> "1" Display : Creates

@enduml