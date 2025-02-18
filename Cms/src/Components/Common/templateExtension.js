import constantType from "../../CommonHelper/Constant/constantType";
import { Image } from "antd";
import ExtensionMixin from "../../CommonHelper/utils/mixins/extension";
import React from "react";
import { useRef,useEffect } from "react";
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
  const divRef = useRef(null);
  useEffect(() => {
    if (divRef.current) {
    divRef.current.firstChild.classList.add("w-100");
    
    }
  }, []);

  const renderTemplate = () => {
    if (constantType.extension.imageTypes.includes(ext)) {
      return <div className="w-100" ref={divRef}>
        <Image className="w-100 object-fit-cover" {...restProps} style={style} src={url} />
      </div>;
    }

    if (constantType.extension.videoTypes.includes(ext)) {
      return (
        <video className="w-100" {...restProps} style={style} controls>
          <source src={url} type={mediaType(ext)} />
        </video>
      );
    }

    if (constantType.extension.audioTypes.includes(ext)) {
      return (
        <audio className="w-100" {...restProps} style={style} controls>
          <source src={url} type={mediaType(ext)} />
        </audio>
      );
    }

    if (constantType.extension.documentTypes.includes(ext) || constantType.extension.compressedTypes.includes(ext)) {
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

export default React.memo(TemplateExtension);
