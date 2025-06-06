import { Tag, Descriptions, Image } from "antd";
import { formatMoneyVn } from "../../CommonHelper/utils/helper/moneyHelper";
import dayjs from "dayjs";
import UseStatusMixin from "../../CommonHelper/utils/mixins/status";
import {
  statusBadge,
  statusStyle,
} from "../../CommonHelper/utils/helper/statusHelper";
import EntityName from "../../Components/Common/entityName";
import services from "../../boot/services";
import { urlApi } from "../../CommonHelper/utils/helper/urlApiFile";

function StaffDetail({ data }) {
  return (
    <div
      style={{
        padding: 16,
        background: "#fafcff",
        borderRadius: 12,
        textAlign: "center",
      }}
    >
      <Descriptions
        bordered
        column={1}
        size="middle"
        labelStyle={{
          width: 180,
          fontWeight: 500,
          background: "#f5f7fa",
          textAlign: "left", // label căn trái
        }}
        contentStyle={{
          fontSize: 16,
          background: "#fff",
          textAlign: "center", // value căn giữa
        }}
      >
        <Descriptions.Item label="Tên nhân viên">{data.name}</Descriptions.Item>
        <Descriptions.Item label="Ảnh đại diện">
          {data.avatar ? (
            <Image
              width={120}
              height={120}
              src={urlApi(data.avatar)}
              alt="avatar"
              style={{ objectFit: "cover", borderRadius: 8 }}
              fallback="/default-avatar.png"
            />
          ) : (
            <Image
              width={120}
              height={120}
              src="/default-avatar.png"
              alt="avatar"
              style={{ objectFit: "cover", borderRadius: 8, opacity: 0.5 }}
            />
          )}
        </Descriptions.Item>
        <Descriptions.Item label="Giới tính">
          <Tag color={statusStyle(UseStatusMixin().gender, data.gender)}>
            {statusBadge(UseStatusMixin().gender, data.gender)}
          </Tag>{" "}
        </Descriptions.Item>
        <Descriptions.Item label="Ngày sinh">
          {data.dateOfBirth ? dayjs(data.dateOfBirth).format("DD/MM/YYYY") : ""}
        </Descriptions.Item>
        <Descriptions.Item label="Số điện thoại">
          {" "}
          {data.phoneNumber}
        </Descriptions.Item>
        <Descriptions.Item label="Email">{data.email}</Descriptions.Item>
        <Descriptions.Item label="Địa chỉ">{data.address}</Descriptions.Item>
        <Descriptions.Item label="Chức vụ">{data.jobName}</Descriptions.Item>
        <Descriptions.Item label="Lương">
          {formatMoneyVn(data.salary)}
        </Descriptions.Item>
        <Descriptions.Item label="Ngày bắt đầu">
          {data.startDate ? dayjs(data.startDate).format("DD/MM/YYYY") : ""}
        </Descriptions.Item>
        <Descriptions.Item label="Ngày kết thúc">
          {data.endDate ? dayjs(data.endDate).format("DD/MM/YYYY") : ""}
        </Descriptions.Item>
        <Descriptions.Item label="Trạng thái">
          <Tag color={statusStyle(UseStatusMixin().staffStatus, data.status)}>
            {statusBadge(UseStatusMixin().staffStatus, data.status)}
          </Tag>
        </Descriptions.Item>
        <Descriptions.Item label="Ngày tạo">
          {data.createdDate
            ? dayjs(data.createdDate).format("DD/MM/YYYY HH:mm")
            : ""}
        </Descriptions.Item>
        <Descriptions.Item label="Người tạo">
          {data.createdByUserName || ""}
        </Descriptions.Item>
        <Descriptions.Item label="Ngày sửa">
          {data.modifiedDate
            ? dayjs(data.modifiedDate).format("DD/MM/YYYY HH:mm")
            : ""}
        </Descriptions.Item>
        <Descriptions.Item label="Người sửa">
          {data.modifiedByUserName || ""}
        </Descriptions.Item>
        <Descriptions.Item label="Tiểu sử">
          {data.biography && (
            <div
              style={{
                maxHeight: 300,
                overflow: "auto",
              }}
              dangerouslySetInnerHTML={{ __html: data.biography }}
            />
          )}
        </Descriptions.Item>
      </Descriptions>
    </div>
  );
}

export default StaffDetail;
