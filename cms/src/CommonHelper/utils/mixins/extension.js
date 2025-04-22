import { FaRegFileWord, FaRegFileExcel, FaRegFilePdf } from "react-icons/fa";
import { PiMicrosoftPowerpointLogoLight } from "react-icons/pi";
import { IoDocumentTextOutline, IoDocumentAttachOutline } from "react-icons/io5";
import { LuFileArchive } from "react-icons/lu";
import { blue, red, green, purple, gray,volcano } from "@ant-design/colors";

function ExtensionMixin() {
  const mediaTypeElement = [
    { extension: ".avi", type: "video/avi" },
    { extension: ".mov", type: "video/quicktime" },
    { extension: ".webm", type: "video/webm" },
    { extension: ".mp4", type: "video/mp4" },
    { extension: ".mp3", type: "audio/mpeg" },
    { extension: ".flac", type: "audio/flac" },
    { extension: ".aac", type: "audio/aac" },
    { extension: ".ogg", type: "audio/ogg" }
  ];

  const displayExtension = [
    {
      extensions: [".doc", ".docx"],
      icon: FaRegFileWord ,
      bgColor:blue[1],
      color: blue[3]
    },
    {
      extensions: [".ppt", ".pptx"],
      icon: PiMicrosoftPowerpointLogoLight ,
      bgColor:volcano[1],
      color: volcano[3]
    },
    {
      extensions: [".xls", ".xlsx"],
      icon: FaRegFileExcel ,
      bgColor:green[2],
      color: green[4]
    },
    {
      extensions: [".pdf"],
      icon: FaRegFilePdf ,
      bgColor:red[1],
      color: red[3]
    },
    {
      extensions: [".odt"],
      icon: IoDocumentAttachOutline ,
      bgColor:blue[3],
      color: blue[7]
    },
    {
      extensions: [".txt"],
      icon: IoDocumentTextOutline ,
      bgColor:gray[1],
      color: gray[4]
    },
    {
      extensions: [".7z", ".rar", ".zip", ".gz"],
      icon: LuFileArchive ,
      bgColor:purple[1],
      color: purple[3]
    }
  ];

  // Flatten extensions to create a lookup table
  const flatDisplayExtension = displayExtension.flatMap(({ extensions, icon,bgColor, color }) =>
    extensions.map(ext => ({ extension: ext, icon, bgColor,color }))
  );

  return {
    mediaTypeElement,
   flatDisplayExtension
  };
}

export default ExtensionMixin;
