To do before the next pull request

[ ] Update documentation
    [ ] Chart.cs
    [ ] MainViewModel.cs
    [ ] Program.cs
    [ ] App.axaml.cs
    [ ] MainWindow.cs
    [ ] ViewUtils.cs
[ ] Create unit tests
    [ ] MatToBitmapConverter.Convert()
        [ ] Working tests
        [ ] Non-mat input
        [ ] Non-bitmap expected output type
    [ ] MatToBitmapConverter.ConvertBack()
        [ ] Working test
        [ ] Non-bitmap input
        [ ] Non-mat expected output type
    [ ] MainViewModel update event runs when
        [ ] IsPdfPickerOpen updates
        [ ] PdfFilePath updates
        [ ] PdfPages has a page added
        [ ] PdfPages has a page removed
        [ ] PdfPages is reordered
        [ ] PdfPages has a page modified
    [ ] MainViewModel.ImportPdf()
        [ ] assert that IsPdfPickerOpen is true
        [ ] update PdfFilePath and change IsPdfPickerOpen to false
        [ ] assert that FilePickerCloseSignal was triggered
[ ] Refactor code
    [ ] Reorganize MainViewModel so that like things are near one another
    [ ] Reorganize MainWindow so that like things are near one another
    [ ] Organize sections under region tags
[-] Make the imported pdf appear in the pdf viewer