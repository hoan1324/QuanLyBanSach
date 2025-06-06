import {
  Card,
  Tag,
  Pagination,
  Button,
  Modal,
  Layout,
  Menu,
  Empty,
  message,
} from "antd";
import React, { useState, useEffect, useCallback } from "react";

import { attachmentFolderRecursion } from "../../CommonHelper/utils/helper/recursionHelper";
import services from "../../boot/services";
import { urlApi } from "../../CommonHelper/utils/helper/urlApiFile";
import TemplateExtension from "../Common/templateExtension";
import FunctionButton from "./functionButton";
import { styleTag } from "../GlobalStyle/Style.js/commonStyle";
import { styleTemplate } from "../GlobalStyle/Style.js/commonStyle";
import {
  getListDropdown,
  getList,
  getListDiffirent,
} from "../../CommonHelper/utils/helper/communicateApi";
import {
  styleCard,
  styleDiv,
  styleHeader,
  styleLayout,
} from "../GlobalStyle/Style.js/fileManageStyle";

const { Header, Footer, Sider, Content } = Layout;

function FileManager({ handleChoose }) {
  const service = services.attachmentFolder;
  const [open, setOpen] = useState(false);
  const [collapsed, setCollapsed] = useState(false);
  const [dataFolder, setDataFolder] = useState([]); // Khởi tạo state để lưu dữ liệu
  const [dataFile, setDataFile] = useState([]); // Khởi tạo state để lưu dữ liệu
  const [currentFileSelect, setCurrentFileSelect] = useState();
  const [currentFolderSelect, setCurrentFolderSelect] = useState();
  const [status, setStatus] = useState("folder");
  const [filter, setFilter] = useState({
    status: "List",
    request: {
      pageIndex: 1,
      orderByColumn: "Name",
    },
  });
  const [totalFile, setTotalFile] = useState();
  const [hover, setHover] = useState(null);
  const fetchData = useCallback(async () => {
    const attachmentFolder = await getListDropdown(service);
    setDataFolder(attachmentFolder);
  }, [service]); // service là dependency
  const fetchDataFile = useCallback(async () => {
    if (filter.status === "List") {
      if (!filter?.request?.filters) {
        return;
      }
      const { data, total } = await getList(
        services.attachment,
        filter.request
      );
      setDataFile(data);
      setTotalFile(total);
    } else {
      const { data, total } = await getListDiffirent(
        service,
        "getFileInFolder",
        true,
        [filter.request]
      );
      setDataFile(data);
      setTotalFile(total);
    }
  }, [filter, service]); // Hàm chỉ được tạo lại khi `filter` hoặc `service` thay đổi

  const handlePageChange = useCallback((page) => {
    setFilter((prevFilter) => ({
      ...prevFilter,
      request: { ...prevFilter.request, pageIndex: page },
    }));
  }, []);
  const handleSelect = useCallback(
    (info, openKeys) => {
      if (!collapsed && info === undefined && openKeys.length === 0) {
        setCurrentFolderSelect(undefined);
        setCurrentFileSelect(undefined);
        setStatus("folder");
        setFilter({
          status: "List",
          request: {
            pageIndex: 1,
            orderByColumn: "Name",
          },
        });
        return;
      }

      if (info !== undefined) {
        const dataSelect = dataFolder.find((item) => item.id === info);
        setCurrentFolderSelect(dataSelect);
        setCurrentFileSelect(undefined);
        setStatus("folder");
        setFilter((prevFilter) => ({
          status: "List",
          request: {
            ...prevFilter.request,
            filters: JSON.stringify([
              {
                filterFields: ["AttachmentFolderId"],
                value: dataSelect?.id,
                condition: "==",
                filterType: "",
              },
            ]),
          },
        }));
      }
    },
    [collapsed, dataFolder]
  ); // Chỉ tạo lại khi `collapsed` hoặc `dataFolder` thay đổi
  const handleClick = useCallback(
    (id) => {
      if (currentFileSelect !== undefined && currentFileSelect.id === id) {
        setCurrentFileSelect(undefined);
        setStatus("folder");
        return;
      }
      const dataClick = dataFile.find((item) => item.id === id);
      setCurrentFileSelect(dataClick);
      setStatus("file");
    },
    [currentFileSelect, dataFile]
  );
  useEffect(() => {
    fetchData();
  }, [fetchData]); // Đưa fetchData vào dependency array
  const handleFinishSearch = (request) => {
    setFilter(request);
  };
  const handleChooseFile = () => {
    if (currentFileSelect === undefined) {
      message.error("Bạn chưa chọn file");
      return;
    }
    handleChoose(currentFileSelect?.url);
    setCurrentFileSelect(undefined);
    setCurrentFolderSelect(undefined);

    setOpen(false);
  };
  useEffect(() => {
    if (!filter?.request) return;
    fetchDataFile();
  }, [filter, fetchDataFile]);
  // Chạy lại khi filter thay đổi
  return (
    <div>
      <Button className="mb-2" onClick={() => setOpen(true)}>
        Chọn ảnh
      </Button>
      <Modal
        className="position-relative overflow-hidden"
        title={"Quản lý file"}
        centered
        width={1100}
        onOk={handleChooseFile}
        onCancel={() => setOpen(false)}
        open={open}
        okText={"Chọn"}
      >
        <Layout className="bg-white rounded" style={styleLayout}>
          <Sider
            className="bg-white"
            trigger={null}
            collapsible
            collapsed={collapsed}
            onMouseOut={() => setCollapsed(true)}
            onMouseOver={() => setCollapsed(false)}
            onCollapse={(value) => setCollapsed(value)}
            width="25%"
          >
            <Menu
              onSelect={(info) => handleSelect(info.key, [])}
              theme="light"
              mode="inline"
              selectedKeys={currentFolderSelect?.id}
              onOpenChange={(openKeys) =>
                handleSelect(openKeys[openKeys.length - 1], openKeys)
              }
              items={attachmentFolderRecursion(dataFolder, null)}
            />
          </Sider>
          <Layout>
            <Header
              style={styleHeader}
              className="border-bottom bg-white px-2 pb-3"
            >
              <FunctionButton
                handleFinish={handleFinishSearch}
                fetchDataFile={fetchDataFile}
                fetchDataFolder={fetchData}
                status={status}
                dataFolder={dataFolder}
                currentFolder={currentFolderSelect}
                currentFile={currentFileSelect}
              />
            </Header>
            <Content
              className={
                dataFile.length > 0
                  ? ""
                  : "d-flex justify-content-center align-items-center"
              }
            >
              {currentFolderSelect !== undefined ||
              (filter.status === "List" &&
                filter.request.filters !== undefined) ? (
                <div>
                  <div
                    className={
                      dataFile.length > 0
                        ? "d-flex ms-3 mt-3 flex-wrap gap-3"
                        : ""
                    }
                  >
                    {dataFile.length > 0 ? (
                      dataFile.map((data, index) => (
                        <Card
                          className="position-relative "
                          key={data.id}
                          styles={{ body: { padding: 0 } }}
                          style={styleCard(currentFileSelect?.id, data?.id)}
                          hoverable
                          onMouseEnter={() => setHover(data.id)}
                          onMouseLeave={() => setHover(null)}
                          onClick={() => handleClick(data.id)}
                        >
                          <Tag color="black" style={styleTag}>
                            {data?.extention?.toUpperCase()}
                          </Tag>
                          <TemplateExtension
                            style={styleTemplate}
                            extension={data?.extention}
                            url={urlApi(data?.url)}
                          />
                          <div className="ps-2 pe-1  py-1 d-flex justify-content-between nowrap border-top">
                            <div>{`${data?.name.substring(0, 15)}${
                              data?.name.length > 15 ? "..." : ""
                            }`}</div>
                            {(currentFileSelect?.id === data.id ||
                              hover === data.id) && (
                              <div
                                style={styleDiv(
                                  hover,
                                  data?.id,
                                  currentFileSelect?.id
                                )}
                              >
                                ✔
                              </div>
                            )}
                          </div>
                        </Card>
                      ))
                    ) : (
                      <Empty />
                    )}
                  </div>
                </div>
              ) : (
                <Empty />
              )}
            </Content>
            {currentFolderSelect !== undefined ||
            (filter.status === "List" &&
              filter.request.filters !== undefined) ? (
              dataFile.length > 0 ? (
                <Footer>
                  <Pagination
                    className="mt-4"
                    align="center"
                    onChange={handlePageChange}
                    current={filter?.request.pageIndex || 1}
                    defaultCurrent={1}
                    pageSize={21}
                    total={totalFile}
                  />
                </Footer>
              ) : (
                <></>
              )
            ) : (
              <></>
            )}
          </Layout>
        </Layout>
      </Modal>
    </div>
  );
}

export default FileManager;
