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
  return result ? result.color : "";
};

function TemplateExtension({ extension, url, ...props }) {
  const ext = extension.toLowerCase();
  const { style = {}, ...restProps } = props;

  const renderTemplate = () => {
    if (imageTypes.includes(ext)) {
      return <Image {...restProps} style={style} src={url} />;
    }

    if (videoTypes.includes(ext)) {
      return (
        <video {...restProps} style={style} controls>
          <source src={url} type={mediaType(ext)} />
        </video>
      );
    }

    if (audioTypes.includes(ext)) {
      return (
        <audio {...restProps} style={style} controls>
          <source src={url} type={mediaType(ext)} />
        </audio>
      );
    }

    if (documentTypes.includes(ext) || compressedTypes.includes(ext)) {
      return (
        <div style={{ backgroundColor: styleExtentsion(ext), ...style }} {...restProps}>
          {iconExtension(ext)}
        </div>
      );
    }

    return <div {...restProps} style={style}>Unsupported file type</div>;
  };

  return renderTemplate();
}

export default TemplateExtension;
