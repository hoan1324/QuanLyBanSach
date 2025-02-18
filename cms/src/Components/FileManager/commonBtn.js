import { useState } from "react";
import { Flex,Tooltip,Button,Form ,Checkbox,Dropdown,Input} from "antd"
import FileUpload from "./fileUpload"
import InputModal from "../Common/inputModal";
import {  AiOutlineExclamationCircle } from "react-icons/ai";
import { CiSearch } from "react-icons/ci";
import constantType from "../../CommonHelper/Constant/constantType";

const CommonButton = ({ handleClick, handleFinish, currentFolder, fetchDataFile }) => {

  return (
    <Flex wrap gap={10}>
      <Tooltip className="position-relative" title={"Chi tiết"}>
        <Button onClick={handleClick} icon={<AiOutlineExclamationCircle />}></Button>
      </Tooltip>
      <SearchFile handleFinish={handleFinish} currentFolder={currentFolder}  />
      <FileUpload fetchDataFile={fetchDataFile} folderId={currentFolder?.id} />
    </Flex>
  )
}
const SearchFile = ({ currentFolder, handleFinish }) => {
  const { imageTypes, compressedTypes, audioTypes, videoTypes, documentTypes}=constantType.extension
  const [open, setOpen] = useState(false)
  const [selectedValues, setSelectedValues] = useState([]);
  const [formSearch] = Form.useForm()
  const handleMenuClick = (checkedValues) => {
    setSelectedValues(checkedValues);
    formSearch.setFieldValue("extension", checkedValues)  // Cập nhật giá trị của Form.Item
  };
  const validateForm = () => {
    const { textSearch, extension } = formSearch.getFieldsValue(['textSearch', 'extension']);


    if (!textSearch && (!extension || extension.length === 0)) {
      return Promise.reject(new Error('Vui lòng nhập ít nhất một trường!'));
    }
    return Promise.resolve();
  }
  const handleSubmit = async () => {
    try {
      await formSearch.validateFields(); // Validate tất cả các trường trước khi submit
      formSearch.submit(); // Submit form nếu validate thành công
    } catch (error) {
      console.log(error);
    }
  };
  const dropdownContent = (
    <Checkbox.Group
      className="d-flex gap-3 wrap rounded border p-3 bg-white shadow"
      style={{ width: 280 }}
      options={[...imageTypes, ...documentTypes, ...videoTypes, ...audioTypes, ...compressedTypes]}
      value={selectedValues}
      onChange={handleMenuClick}
    />
  );
  const onFinish = (values) => {
    console.log('Form values:', values);
  
    let filterRequest = {
      status:"",
      request:{
        pageIndex:1
      }
    };
  
    if (currentFolder=== undefined) {
      let config = [];
  
      if (values.textSearch?.trim()) {
        config.push({
          filterFields: ["Name", "Extention"],
          value: values.textSearch.trim(),
          condition: "contain",
          filterType: "String"
        });
      }
  
      if (values.extension?.length > 0) {
        config.push({
          filterFields: ["Extention"],
          value: values.extension,
          condition: "contain",
          filterType: "String"
        });
      }
  
      filterRequest = {
        status:"List",
        request:{...filterRequest.request,
            orderByColumn: "Name",
            filters: JSON.stringify(config)
        }
      };
    } else {
      filterRequest = {
        status:"InFolder",
        request:{
        ...filterRequest.request,
        folderId:currentFolder?.id,
        textSearch: values.textSearch?.trim() || null,
        ext: values.extension?.length > 0 ? JSON.stringify(values.extension) : null
        }
      };
    }
    
    handleClose()
    handleFinish(filterRequest)
    
    
  };
  const handleClose=()=>{
    if(open){
      formSearch.resetFields()
      setSelectedValues([])
      setOpen(false)
    }
  }
  return (
    <>
      <Tooltip title={"Tìm kiếm tên tệp"}>
        <Button onClick={() => setOpen(true)} icon={<CiSearch />}></Button>
      </Tooltip>
      <InputModal handleOk={handleSubmit} handleClose={handleClose} isOpen={open} title={currentFolder === undefined ? "Tìm kiếm tệp" : `Tìm kiếm trong thư mục ${currentFolder?.name}`}>
        <Form onFinish={onFinish} name="searchFile" layout="vertical" form={formSearch}>
          <Form.Item rules={[{ validator: validateForm }]} label="Tên tệp" name="textSearch" >
            <Input placeholder="Nhập dữ liệu"  ></Input>
          </Form.Item>
          <Form.Item name="extension" >
            <Dropdown dropdownRender={() => <div>{dropdownContent}</div>} placement="bottomRight" trigger={['click']}>
              <Button>Chọn phần mở rộng file cần tìm</Button>
            </Dropdown>
          </Form.Item>
        </Form>
      </InputModal>
    </>
  )
}
export default CommonButton