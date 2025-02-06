import { FaRegFileWord, FaRegFileExcel, FaRegFilePdf } from "react-icons/fa";
import { PiMicrosoftPowerpointLogoLight } from "react-icons/pi";
import { IoDocumentTextOutline, IoDocumentAttachOutline } from "react-icons/io5";
import { LuFileArchive } from "react-icons/lu";
import { blue, red, green, purple, gray } from "@ant-design/colors";

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
      icon: <FaRegFileWord />,
      color: blue[5]
    },
    {
      extensions: [".ppt", ".pptx"],
      icon: <PiMicrosoftPowerpointLogoLight />,
      color: red[5]
    },
    {
      extensions: [".xls", ".xlsx"],
      icon: <FaRegFileExcel />,
      color: green[2]
    },
    {
      extensions: [".pdf"],
      icon: <FaRegFilePdf />,
      color: red[2]
    },
    {
      extensions: [".odt"],
      icon: <IoDocumentAttachOutline />,
      color: blue[7]
    },
    {
      extensions: [".txt"],
      icon: <IoDocumentTextOutline />,
      color: gray[5]
    },
    {
      extensions: [".7z", ".rar", ".zip", ".gz"],
      icon: <LuFileArchive />,
      color: purple[3]
    }
  ];

  // Flatten extensions to create a lookup table
  const flatDisplayExtension = displayExtension.flatMap(({ extensions, icon, color }) =>
    extensions.map(ext => ({ extension: ext, icon, color }))
  );

  return {
    mediaTypeElement,
   flatDisplayExtension
  };
}

export default ExtensionMixin;
