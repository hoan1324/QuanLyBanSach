import { imageTypes, documentTypes, videoTypes, audioTypes, compressedTypes } from "../../CommonHelper/Constant/extensionFiles";
import { Image } from "antd";
import ExtensionMixin from "../../CommonHelper/utils/mixins/extension";

const { mediaTypeElement, flatDisplayExtension } = ExtensionMixin();

const mediaType = (extension) => {
  const result = mediaTypeElement.find(item => item.extension === extension);
  return result ? result.type : "";
};

const iconExtension = (extension) => {
  const result = flatDisplayExtension.find(item => item.extension === extension);
  return result ? result.icon : null;
};

const styleExtentsion = (extension) => {
  const result = flatDisplayExtension.find(item => item.extension === extension);
  return result ? result : {};
};

function TemplateExtension({ extension, url, ...props }) {
  const ext = extension?.toLowerCase();
  const { style = {}, ...restProps } = props;

  const renderTemplate = () => {
    if (imageTypes.includes(ext)) {
      return <Image className="w-100" {...restProps} style={style} src={url} />;
    }

    if (videoTypes.includes(ext)) {
      return (
        <video className="w-100" {...restProps} style={style} controls>
          <source src={url} type={mediaType(ext)} />
        </video>
      );
    }

    if (audioTypes.includes(ext)) {
      return (
        <audio className="w-100" {...restProps} style={style} controls>
          <source src={url} type={mediaType(ext)} />
        </audio>
      );
    }

    if (documentTypes.includes(ext) || compressedTypes.includes(ext)) {
      const Icon=iconExtension(ext)
      return (
        <div className=" w-100 d-flex justify-content-center align-items-center" style={{
          backgroundColor: styleExtentsion(ext)?.bgColor,
          borderRadius: "8px 8px 0 0", ...style,
        }} {...restProps}>
          <Icon style={{fontSize:"100px",color:styleExtentsion(ext)?.color}} />
        </div>
      );
    }

    return <div {...restProps} style={style}>Unsupported file type</div>;
  };

  return renderTemplate();
}

export default TemplateExtension;
