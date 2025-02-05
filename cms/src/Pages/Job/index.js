import services from "../../boot/services";
import { Tooltip, Table, Pagination, Button, Form, InputNumber, Divider, Input, message, Flex, Space } from "antd";

import { IoIosAddCircleOutline } from "react-icons/io";
import { SearchOutlined } from '@ant-design/icons';
import { useForm } from "antd/es/form/Form";

import { useContext, useEffect, useState, useCallback } from "react";
import { columnNameJob } from "../../CommonHelper/Constant/columnName";
import InputModal from "../../Components/Common/inputModal";
import TextArea from "antd/es/input/TextArea";

// Chuyển đổi dữ liệu API thành định dạng phù hợp cho bảng
const dataSource = (data) => {
  return data.map((element) => ({
    key: element.id,
    jobName: element.jobName,
    salaryMin: element.salaryMin,
    salaryMax: element.salaryMax,
    description: element.description
  }));
};

// Hàm lấy danh sách công việc và tổng số công việc
const fetchJobsData = async (jobService, filter) => {
  try {
    const jobsResponse = await jobService.getList(filter)


    if (jobsResponse.isSuccess) {
      return { jobs: jobsResponse.data.data, total: jobsResponse.data.totalRow };
    }
    return { jobs: [], total: 0 };
  } catch (error) {
    console.error("Lỗi trong fetchJobsData:", error);
    return { jobs: [], total: 0 };
  }
};
const actionJobData = async (jobService, jobData) => {
  try {
    let response;
    if (jobData.id === undefined) {
      response = await jobService.create(jobData)
    }
    else {
      response = await jobService.update(jobData.id, jobData)
    }
    if (response.status === 500) {
      return { isSuccess: false, message: response.message };
    }
    return response
  }
  catch (error) {
    console.log("lỗi vào đây");
    return {
      isSuccess: false,
      message: "Có lỗi xảy ra trong quá trình xử lý.",
    };
  }
}
const deleteJobData = async (jobService, id) => {
  try {
    const response = await jobService.delete(id)
    if (response.status === 500) {
      return { isSuccess: false, message: response.message };
    }
    return response
  }
  catch (error) {
    console.log("lỗi vào đây");
    return {
      isSuccess: false,
      message: "Có lỗi xảy ra trong quá trình xử lý.",
    };
  }
}
const findJob = async (jobService,id) => {
  try {
    const response = await jobService.getById(id)
    if (response.status === 500 || !response.isSuccess) {
      return null;
    }
    return response.data;
  }
  catch (error) {
    console.log(error);
    return null

  }
}
function Job() {
  const service = services.jobService; // Lấy jobService từ context
  const [data, setData] = useState([]); // Khởi tạo state để lưu dữ liệu
  const [total, setTotal] = useState(1); // Tổng số công việc
  const [filter, setFilter] = useState({
    pageIndex: 1,
    pageSize: 20,
    orderByColumn:"CreatedDate"||null, 
  });

  const [title, setTitle] = useState();
  const [open, setOpen] = useState(false);
  const [jobData, setJobData] = useState({})
  const [disabled, setDisabled] = useState(false)
  const [form] = useForm();
  const [formSearch] = useForm()
  const [messageApi, contextHolder] = message.useMessage();
  const [configFilter, setConfigFilter] = useState(
    [
      {
        filterFields: ["JobName", "Description"],
        value: null,
        condition: "contain",
        filterType: "textbox",
        title: "Tìm kiếm"
      }
    ]
  )
  const validateSalaryRange = (_, value) => {
    const salaryMin = form.getFieldValue('salaryMin');
    const salaryMax = form.getFieldValue('salaryMax');
    
    if (salaryMin !== undefined && salaryMax !== undefined && salaryMin > salaryMax) {
      return Promise.reject('Mức lương tối thiểu không được lớn hơn mức lương tối đa!');
    }
    return Promise.resolve();
  };

  // Hàm lấy dữ liệu công việc từ API
  const fetchData = useCallback(async () => {
    
    const { jobs, total } = await fetchJobsData(service, filter);
    console.log(jobs);
    
    
    setData(jobs);
    setTotal(total);
  }, [filter, service]);

  const handleOpenModel = (title) => {
    if (!open) {
      {
        setTitle(title)
        setOpen(true)
      }
    }
  }
  const handleClose = () => {
    if (open) {
      {
        form.resetFields()
        setOpen(false)
        if (disabled) {
          setDisabled(false)
        }

      }
    }
  }
  // Lắng nghe thay đổi filter (khi thay đổi trang)
  useEffect(() => {

    fetchData();
  }, [fetchData]); // Chạy lại khi filter thay đổi

  // Xử lý sự kiện khi thay đổi trang
  const handlePageChange = (page) => {
    setFilter(prevFilter => ({
      ...prevFilter,
      pageIndex: page
    }));
  };
  const handleSubmit = async () => {
    try {
      await form.validateFields(); // Validate tất cả các trường trước khi submit
      form.submit(); // Submit form nếu validate thành công
    } catch (error) {
      console.log('Vui lòng kiểm tra các trường hợp lỗi!');
    }
  };

  const onFinish = async (values) => {
    try {
      const response = await actionJobData(service, values);
      console.log(response.messsage);

      if (response.isSuccess) {

        messageApi.open({
          type: 'success',
          content: response.messsage,
        });
        fetchData(); // Làm mới dữ liệu
      } else {
        messageApi.open({
          type: 'error',
          content: response.messsage,
        });
      }
    } catch (error) {
      messageApi.open({
        type: 'error',
        content: "Có lỗi xảy ra khi xử lý dữ liệu",
      });
    } finally {
      handleClose();
    }
  }
  const handleEdit = async (id) => {
    const response = await findJob(service,id);
    setJobData(response);
    form.setFieldsValue(response)
    handleOpenModel("Chỉnh sửa công việc")

  }
  const handleDetail = async (id) => {
    const response = await findJob(service,id);
    setDisabled(true)
    setJobData(response);
    form.setFieldsValue(response)
    handleOpenModel("Thông tin công việc")
  }
  const handleDelete = async (id) => {
    try {
      const response = await deleteJobData(service, id);
      console.log(response.messsage);

      if (response.isSuccess) {

        messageApi.open({
          type: 'success',
          content: response.messsage,
        });
        fetchData(); // Làm mới dữ liệu
      } else {
        messageApi.open({
          type: 'error',
          content: response.messsage,
        });
      }
    } catch (error) {
      messageApi.open({
        type: 'error',
        content: "Có lỗi xảy ra khi xử lý dữ liệu",
      });
    }
  }
  const onFinishSearch = (values) => {
     var jsonConvert=JSON.stringify(assinValue(values))
     setFilter(pre=>{
      return{
        ...pre,
        filters:jsonConvert
      }
     })    
     formSearch.resetFields() 
  }
  const assinValue = (values) => {
    const filter = configFilter.map((element, index) => (
      {
        filterFields: element.filterFields,
        value: values[element.filterFields.join(",")],
        condition: element.condition,
        filterType: element.filterType
      }
    ))
    return filter
  }
  return (
    <div>

      <div className="d-flex justify-content-end mb-3">
        <Button size="large" onClick={(e) => handleOpenModel('Tạo mới công việc')} icon={<IoIosAddCircleOutline />} type="primary">
          Thêm mới
        </Button>
      </div>
      <div className="mb-3">
        <Form form={formSearch} onFinish={onFinishSearch}>
          <Flex gap="small" justify="end" align="center" wrap>
            {configFilter.map((element, index) => (
              <Form.Item key={index} className="mb-0" name={element.filterFields.join(",")} rules={[
                {
                  required: true,
                  message: 'Nhập dữ liệu',
                },
              ]} >
                <Input size="large" placeholder={element.title} />
              </Form.Item>
            ))}
            <Tooltip title="Tìm kiếm">
              <Button size="large" shape="circle" htmlType="submit" icon={<SearchOutlined />} />
            </Tooltip>
          </Flex>
        </Form>
      </div>
      <Table loading={data==[]?true:false} dataSource={dataSource(data)} rowKey="key" scroll={{ x: 'max-content', }} pagination={false} bordered columns={columnNameJob({ handleEdit, handleDelete, handleDetail })} />
      <Pagination className="mt-4" align="center" onChange={handlePageChange} current={filter.pageIndex} defaultCurrent={1} pageSize={filter.pageSize} total={total} />
      <InputModal diasbled={disabled} title={title} handleOk={handleSubmit} handleClose={handleClose} width={1000} isOpen={open}>
        <Divider />
        <Form disabled={disabled} form={form} onFinish={onFinish} name="jobForm" layout="vertical">
          <Form.Item name="id" hidden value={jobData.id}>
            <Input disabled />
          </Form.Item>
          <Form.Item label="Tên công việc" name="jobName" rules={[{ required: true, message: "Vui lòng nhập tên công việc" }]}>
            <Input placeholder="Nhập tên công việc" className="w-100"></Input>
          </Form.Item>
          <div className="row">
            <Form.Item className="col-md-6" label="Lương tối thiểu (VNĐ)" name="salaryMin"

              rules={[
                { required: true, message: 'Vui lòng nhập mức lương tối thiểu!' },
                { validator: validateSalaryRange },
              ]}
            >
              <InputNumber placeholder="Nhập mức lương tối thiểu" className="w-100" min={0} />
            </Form.Item>
            <Form.Item className="col-md-6" label="Lương tối đa (VNĐ)" name="salaryMax"
              rules={[
                { required: true, message: 'Vui lòng nhập mức lương tối đa!' },
                { validator: validateSalaryRange },
              ]}>
              <InputNumber placeholder="Nhập mức lương tối đa" style={{ width: '100%' }} min={0} />
            </Form.Item>
          </div>
          <Form.Item label="Mô tả công việc" name="description" >
            <TextArea placeholder="Nhập mô tả công việc"
              autoSize={{
                minRows: 4,
                maxRows: 6,
              }}></TextArea>
          </Form.Item>
        </Form>
      </InputModal>

    </div>
  );
}

export default Job;
