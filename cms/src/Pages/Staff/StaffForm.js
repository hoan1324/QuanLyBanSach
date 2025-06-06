import { Form, InputNumber, Input, message, Tag } from "antd";
import { DatePicker, Select } from "antd";
import { useState, useRef } from "react";
import dayjs from "dayjs";

import services from "../../boot/services";
import UseStatusMixin from "../../CommonHelper/utils/mixins/status";
import Editor from "../../boot/ckEditor";

import usePageStore from "../../store/pageStore";
import vnConst from "../../i18vn/vi-VN";
import { formatMoneyVn } from "../../CommonHelper/utils/helper/moneyHelper";
import FileManager from "../../Components/FileManager/fileManager";
import TemplateExtension from "../../Components/Common/templateExtension";
import { styleTemplate } from "../../Components/GlobalStyle/Style.js/commonStyle";
import { urlApi } from "../../CommonHelper/utils/helper/urlApiFile";
import { styleTag } from "../../Components/GlobalStyle/Style.js/commonStyle";
import constantType from "../../CommonHelper/Constant/constantType";
import useFetchList from "../../hooks/useFetchList";

function StaffForm({ form, fileSelect, setFileSelect }) {
  const { data } = useFetchList(services.jobService);

  const selectJob = useRef(null);
  const { getDetailData } = usePageStore();

  const handleSelect = (_, value) => {
    console.log("Vaf Handleselect");
    console.log(value);
  };

  const validateEndDate = (_, value) => {
    const valueStatus = form.getFieldValue("status");
    const { staffStatus } = UseStatusMixin(); // Giả sử bạn có hàm này trả về status

    var search = staffStatus.find((item) => item.id === valueStatus);
    if (search !== null) {
      if (search.name === vnConst.currentlyEmployed) {
        form.setFieldsValue({ endDate: null });
      }
      if (search.name === vnConst.resigned) {
        if (!form.getFieldValue("endDate")) {
          form.setFieldsValue({ endDate: dayjs() });
        }
      }
    }

    return Promise.resolve();
  };

  const validateSalary = (_, value) => {
    const valueSelect = form.getFieldValue("jobID");
    if (!valueSelect) return Promise.reject("Vui lòng chọn công việc");

    const selectJob = data?.find((item) => item.id === valueSelect);
    if (!selectJob) return Promise.reject("Công việc không hợp lệ");

    const { salaryMin, salaryMax } = selectJob;

    if (
      (salaryMin !== null && value < salaryMin) ||
      (salaryMax !== null && value > salaryMax)
    ) {
      return Promise.reject(`Lương phải từ ${formatMoneyVn(salaryMin)}
          đến ${salaryMax ? formatMoneyVn(salaryMax) : "vô cùng"}`);
    }

    return Promise.resolve();
  };

  const handleChoose = (fileSelect) => {
    if (
      !constantType.extension.imageTypes.includes(
        (typeof fileSelect === "string" &&
          fileSelect.match(/(\.[0-9a-z]+)$/i)?.[1]) ||
          ""
      )
    ) {
      message.error("File không phải là ảnh");
      return;
    }
    console.log("File selected:", fileSelect);

    setFileSelect(fileSelect);
    form.setFieldValue("avatar", fileSelect);
  };

  return (
    <>
      <Form.Item hidden name="avatar">
        <Input disabled />
      </Form.Item>
      <div className="mb-2">Ảnh đại diện:</div>
      {console.log("File select:", fileSelect)}
      {fileSelect === null ? (
        <FileManager className="mt-3" handleChoose={handleChoose} />
      ) : (
        <div
          className="position-relative p-2 border mb-3 mt-3"
          style={{ width: 150 }}
        >
          <Tag
            color="red"
            onClick={() => {
              setFileSelect(null);
              form.setFieldValue("avatar", null);
            }}
            style={styleTag}
          >
            X
          </Tag>
          <TemplateExtension
            style={styleTemplate}
            url={urlApi(fileSelect)}
            extension={
              (typeof fileSelect === "string" &&
                fileSelect.match(/(\.[0-9a-z]+)$/i)?.[1]) ||
              ""
            }
          />
        </div>
      )}

      <Form.Item
        label="Tên nhân viên"
        name="name"
        rules={[{ required: true, message: "Vui lòng nhập tên nhân viên" }]}
      >
        <Input placeholder="Nhập tên nhân viên" className="w-100"></Input>
      </Form.Item>
      <div className="row">
        <div className="col-md-4">
          <Form.Item
            label="Ngày sinh"
            name="dateOfBirth"
            rules={[{ required: true, message: "Vui lòng nhập ngày sinh" }]}
          >
            <DatePicker format="DD/MM/YYYY" className="w-100" />
          </Form.Item>
        </div>
        <div className="col-md-4">
          <Form.Item
            label="Ngày bắt đầu làm việc"
            name="startDate"
            rules={[{ required: true, message: "Vui lòng nhập ngày bắt đầu" }]}
          >
            <DatePicker format="DD/MM/YYYY" className="w-100" />
          </Form.Item>
        </div>
        <div className="col-md-4">
          <Form.Item
            dependencies={["status"]}
            rules={[{ validator: validateEndDate }]}
            label="Ngày kết thúc làm việc"
            name="endDate"
          >
            <DatePicker format="DD/MM/YYYY" className="w-100" />
          </Form.Item>
        </div>
      </div>
      <div className="row">
        <div className="col-md-6">
          <Form.Item
            label="Số điện thoại"
            name="phoneNumber"
            rules={[
              { required: true, message: "Vui lòng nhập số điện thoại" },
              { pattern: /^[0-9]+$/, message: "Số điện thoại phải là số" },
            ]}
          >
            <Input
              placeholder="Nhập số điện thoại"
              style={{ width: "100%" }}
              min={0}
            />
          </Form.Item>
        </div>
        <div className="col-md-6">
          <Form.Item
            label="Email"
            name="email"
            rules={[
              { required: true, message: "Vui lòng nhập email" },
              { type: "email", message: "Địa chỉ phải là email " },
            ]}
          >
            <Input placeholder="Nhập email" style={{ width: "100%" }} min={0} />
          </Form.Item>
        </div>
      </div>
      <div className="row">
        <div className="col-md-6">
          <Form.Item
            label="Giới tính"
            name="gender"
            rules={[{ required: true, message: "Vui lòng chọn giới tính" }]}
          >
            <Select
              className="w-100"
              options={UseStatusMixin().gender.map((element, index) => ({
                value: element.id,
                label: element.name,
              }))}
            />
          </Form.Item>
        </div>
        <div className="col-md-6">
          <Form.Item
            label="Trạng thái"
            name="status"
            rules={[{ required: true, message: "Vui lòng chọn trạng thái" }]}
          >
            <Select
              className="w-100"
              options={UseStatusMixin().staffStatus.map((element, index) => ({
                value: element.id,
                label: element.name,
              }))}
            />
          </Form.Item>
        </div>
      </div>
      <div className="row">
        <div className="col-md-6">
          <Form.Item
            dependencies={["jobID"]}
            label="Lương nhân viên"
            name="salary"
            rules={[
              { required: true, message: "Vui lòng chọn lương nhân viên" },
              { validator: validateSalary },
            ]}
          >
            <InputNumber
              placeholder="Nhập  lương nhân viên"
              style={{ width: "100%" }}
              min={0}
            />
          </Form.Item>
        </div>
        <div className="col-md-6">
          <Form.Item
            label="Công việc"
            name="jobID"
            rules={[
              { required: true, message: "Vui lòng chọn vị trí nhân viên" },
            ]}
          >
            <Select
              className="w-100"
              key={getDetailData()}
              onSelect={handleSelect}
              ref={selectJob}
              options={
                data
                  ? data.map((element, index) => ({
                      value: element.id,
                      label: element.name,
                      salaryMax: element.salaryMax,
                      salaryMin: element.salaryMin,
                    }))
                  : {}
              }
            />
          </Form.Item>
        </div>
      </div>
      <Form.Item
        label="Địa chỉ"
        name="address"
        rules={[{ required: true, message: "Vui lòng nhập địa chỉ" }]}
      >
        <Input.TextArea
          placeholder="Nhập địa chỉ"
          autoSize={{
            minRows: 2,
            maxRows: 4,
          }}
        ></Input.TextArea>
      </Form.Item>
      <Form.Item label="Tiểu sử nhân viên" name="biography">
        <Editor
          data={getDetailData().biography ?? ""}
          onChange={(event, editor) => {
            const data = editor.getData();
            form.setFieldsValue({ biography: data }); // Cập nhật vào form
          }}
        />
      </Form.Item>
    </>
  );
}
export default StaffForm;
