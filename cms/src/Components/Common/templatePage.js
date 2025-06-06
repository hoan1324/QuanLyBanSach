import { Table, Pagination, Button, Form, Divider, Input, message } from "antd";
import { IoIosAddCircleOutline } from "react-icons/io";
import { useState } from "react";
import InputModal from "../../Components/Common/inputModal";
import FormSearch from "../Common/formSearch";
import {
  actionAsync,
  deleteAsync,
  findByID,
} from "../../CommonHelper/utils/helper/communicateApi";
import usePageStore from "../../store/pageStore";
import usePagingFilter from "../../hooks/usePagingFilter";
import useFetchListFilter from "../../hooks/useFetchListFilter";
import useHasPermission from "../../hooks/useHasPermission";

// TemplatePage component chính
function TemplatePage({ config, ModalForm, ModalDetail }) {
  const { filter, setPage, setFilters, resetFilter } = usePagingFilter({
    orderByColumn: config?.orderByColumn ?? "CreatedDate",
  });
  const { data, total, refresh } = useFetchListFilter(config?.service, filter);

  const [title, setTitle] = useState();
  const [open, setOpen] = useState(false);
  const [disabled, setDisabled] = useState(false);
  const [defaultForm] = Form.useForm();
  const { getDetailData, setDetailData } = usePageStore();
  const [modalType, setModalType] = useState("edit");

  const form = config?.form ?? defaultForm;

  const handleOpenModal = (title) => {
    setTitle(title);
    setOpen(true);
  };

  const handleClose = () => {
    form.resetFields();
    setDetailData({});
    setOpen(false);
    setDisabled(false);
    setModalType("edit");
  };

  const handleSubmit = async () => {
    try {
      await form.validateFields();
      form.submit();
    } catch (error) {
      console.log("Vui lòng kiểm tra các trường hợp lỗi!");
    }
  };

  const handleSearch = (filterValue) => {
    console.log("fillterValue");

    console.log(filterValue);

    setFilters(filterValue);
  };

  const onFinish = async (values) => {
    try {
      const response = await actionAsync(
        config?.service,
        config.transferRequest ? config.transferRequest(values) : values
      );

      if (response.isSuccess) {
        message.success(response.message);
        resetFilter();
        refresh(); // Refresh data after submission
      } else {
        message.error(response.message);
      }
    } catch (error) {
      message.error("Có lỗi xảy ra khi xử lý dữ liệu");
    } finally {
      handleClose();
    }
  };

  const handleEdit = async (id) => {
    const response = await findByID(config?.service, id);
    if (config?.form && config?.urlActionAsisign) {
      config.urlActionAsisign(response);
    }
    setDetailData(response);
    form.setFieldsValue(
      config.transferResponse ? config.transferResponse(response) : response
    );
    handleOpenModal(`Chỉnh sửa ${config?.modalName}`);
  };

  const handleDetail = async (id) => {
    const response = await findByID(config?.service, id);
    if (config?.form && config?.actiocAssignUrl) {
      config.u(response);
    }
    setDetailData(response);
    setModalType("detail");
    setDisabled(true);
    handleOpenModal(`Thông tin ${config?.modalName}`);
  };

  const handleDelete = async (id) => {
    try {
      const response = await deleteAsync(config?.service, id);

      if (response.isSuccess) {
        message.success(response.message);
        resetFilter();
        refresh(); // Refresh data after submission
      } else {
        message.error(response.message);
      }
    } catch (error) {
      message.error("Có lỗi xảy ra khi xử lý dữ liệu");
    }
  };

  return (
    <div>
      <div className="d-flex justify-content-between align-items-center mb-3">
        <h4 className="mb-0">{config?.title}</h4>
        {useHasPermission(`${config?.permissionController}-CreateAsync`) && (
          <Button
            size="large"
            onClick={() => handleOpenModal(`Tạo mới ${config?.modalName}`)}
            icon={<IoIosAddCircleOutline />}
            type="primary"
          >
            Thêm mới
          </Button>
        )}
      </div>
      <FormSearch handleSearch={handleSearch} filters={config?.filters} />
      <Table
        dataSource={config?.dataSource(
          data,
          filter?.pageIndex,
          filter?.pageSize
        )}
        rowKey="key"
        scroll={{ x: "max-content" }}
        pagination={false}
        bordered
        columns={config?.column({ handleEdit, handleDelete, handleDetail })}
      />
      <Pagination
        className="mt-4"
        align="center"
        onChange={(page) => setPage(page)}
        current={filter.pageIndex}
        defaultCurrent={1}
        pageSize={filter.pageSize}
        total={total}
      />
      <InputModal
        disabled={disabled}
        title={title}
        handleOk={handleSubmit}
        handleClose={handleClose}
        width={1000}
        isOpen={open}
      >
        <Divider />
        {modalType === "detail" ? (
          <ModalDetail data={getDetailData()} />
        ) : (
          <Form
            disabled={disabled}
            form={form}
            onFinish={onFinish}
            name="form"
            layout="vertical"
          >
            <Form.Item name="id" hidden>
              <Input disabled />
            </Form.Item>
            <ModalForm />
          </Form>
        )}
      </InputModal>
    </div>
  );
}

export default TemplatePage;
