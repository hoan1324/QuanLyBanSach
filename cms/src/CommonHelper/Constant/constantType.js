export default{
    filterCondition: {
        contain: "contain",
        equal: "==",
        notEqual: "!=",
        greeterThan: ">",
        lessThan: "<",
        gtEqual: ">=",
        lsEqual: "<="
    },
    filterType: {
        textBox: 0,
        selectBox: 1,
        dateTimePicker: 2,
        rangeDatePicker: 3,
    },
    extension:{
        imageTypes : ['.jpeg','.jpg','.png','.gif','.bmp','.webp','.tiff'] ,
        documentTypes : ['.doc','.docx','.ppt','.pptx','.xls','.xlsx','.odt','.pdf','.txt'],
        videoTypes : ['.avi','.mov','.webm','.mp4'],
        audioTypes : ['.mp3','.flac','.aac','.ogg'],
        compressedTypes : ['.7z','.rar','.zip','.gz'],
    }

}