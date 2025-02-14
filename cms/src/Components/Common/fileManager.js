import { Card, Tag, Pagination, Button, Modal, Layout, Menu, Empty } from "antd";
import { useState, useEffect, useCallback } from "react";
import { attachmentFolderRecursion } from "../../CommonHelper/utils/helper/recursionHelper";

import services from "../../boot/services";
import { urlApi } from "../../CommonHelper/utils/helper/urlApiFile";
import TemplateExtension from "./templateExtension";
import FunctionButton from "./functionButton";
const { Header, Footer, Sider, Content } = Layout;

const fetchAttachmentFolderData = async (service) => {
  try {
    const response = await service.getListDropdown()

    if (response.isSuccess) {

      return response.data;
    }

    return [];
  } catch (error) {
    console.error("Lỗi", error);
    return [];
  }
};
const fetchAttachmentInFolder = async (service, request) => {
  try {
    const response = await service.getFileInFolder(request)

    if (response.isSuccess) {

      return { attachment: response.data.data, total: response.data.totalRow };

    }
    return { attachment: [], total: 0 };


  } catch (error) {
    console.error("Lỗi", error);
    return { attachment: [], total: 0 };
  }
}
const fetchAttachmentData = async (service, request) => {
  try {
    const response = await service.getList(request)

    if (response.isSuccess) {

      return { attachment: response.data.data, total: response.data.totalRow };

    }
    return { attachment: [], total: 0 };


  } catch (error) {
    console.error("Lỗi", error);
    return { attachment: [], total: 0 };
  }
};

function FileManager() {
  const service = services.attachmentFolder;
  const [open, setOpen] = useState(false)
  const [collapsed, setCollapsed] = useState(false);
  const [dataFolder, setDataFolder] = useState([]); // Khởi tạo state để lưu dữ liệu
  const [dataFile, setDataFile] = useState([]); // Khởi tạo state để lưu dữ liệu
  const [currentFileSelect, setCurrentFileSelect] = useState()
  const [currentFolderSelect, setCurrentFolderSelect] = useState()
  const [status, setStatus] = useState("folder")
  const [filter, setFilter] = useState({
    status: "List",
    request: {
      pageIndex: 1,
      orderByColumn: "Name",
    }
  })
  const [totalFile, setTotalFile] = useState()
  const [hover, setHover] = useState(null)
  const fetchData = async () => {
    const attachmentFolder = await fetchAttachmentFolderData(service);
    setDataFolder(attachmentFolder);
  }
  const fetchDataFile = async () => {
    if (filter.status === "List") {
      const { attachment, total } = await fetchAttachmentData(services.attachment, filter.request);
      setDataFile(attachment);
      setTotalFile(total);
    }
    else {
      const { attachment, total } = await fetchAttachmentInFolder(service, filter.request);
      setDataFile(attachment);
      setTotalFile(total);
    }


  };
  const handlePageChange = (page) => {
    setFilter(prevFilter => ({
      ...prevFilter,
      request: { ...prevFilter.request, pageIndex: page },
    }));
  };
  const handleSelect = (info, openKeys) => {
    if (!collapsed && info === undefined && openKeys.length === 0) {
      setCurrentFolderSelect(undefined)
      setCurrentFileSelect(undefined)
      setStatus("folder")
      setFilter({
        status: "List",
        request: {
          pageIndex: 1,
          orderByColumn: "Name",
        }
      })
    }
    if (info !== undefined) {
      const dataSelect = dataFolder.find(item => item.id === info)
      setCurrentFolderSelect(dataSelect)
      setCurrentFileSelect(undefined)
      setStatus("folder")
      setFilter(prevFilter => ({
        status: "List",
        request: {
          ...prevFilter.request,
          filters: JSON.stringify([
            {
              filterFields: ["AttachmentFolderId"],
              value: dataSelect?.id,
              condition: "==",
              filterType: ""

            }
          ]),
        }

      }))
    }
  }
  const handleClick = (id) => {
    if (currentFileSelect !== undefined && currentFileSelect.id === id) {
      setCurrentFileSelect(undefined)
      setStatus("folder")
      return
    }
    const dataClick = dataFile.find(item => item.id === id)
    setCurrentFileSelect(dataClick)
    setStatus("file")
  }
  useEffect(() => {
    fetchData();
  }, []);
const handleFinishSearch=(request)=>{
  setFilter(request)
}
  useEffect(() => {
    if ((filter.status === "List" && filter.request?.filters === undefined) || (filter.status === "InFolder" && filter.request === undefined)) {
      return;
    }
    fetchDataFile()
  }, [filter])
  // Chạy lại khi filter thay đổi
  return (
    <div>
      <Button onClick={() => setOpen(true)}> Mở</Button>
      <Modal
        className="position-relative overflow-hidden" title={"Quản lý file"} centered width={1100} onCancel={() => setOpen(false)} open={open} okText={"Chọn"}>
        <Layout className="bg-white rounded" style={{ minHeight: '800px' }}>
          <Sider className="bg-white" trigger={null} collapsible collapsed={collapsed} onMouseOut={() => setCollapsed(true)} onMouseOver={() => setCollapsed(false)} onCollapse={(value) => setCollapsed(value)} width="25%" >
            <Menu
              onSelect={(info) => handleSelect(info.key, [])}
              theme="light"
              mode="inline"
              selectedKeys={currentFolderSelect?.id}
              onOpenChange={(openKeys) => handleSelect(openKeys[openKeys.length - 1], openKeys)}
              items={
                attachmentFolderRecursion(dataFolder, null)
              }
            />
          </Sider>
          <Layout>
            <Header style={{ height: "fit-content" }} className="border-bottom bg-white px-2 pb-3" >
              <FunctionButton handleFinish={handleFinishSearch} resetField={() => setCurrentFolderSelect(undefined)} fetchDataFile={fetchDataFile} fetchDataFolder={fetchData} status={status} dataFolder={dataFolder} currentFolder={currentFolderSelect} currentFile={currentFileSelect} />
            </Header>
            <Content className={dataFile.length > 0 ? "" : "d-flex justify-content-center align-items-center"}>
              {currentFolderSelect !== undefined || (filter.status === "List" && filter.request.filters !== undefined) ? (
                <div>
                  <div className={dataFile.length > 0 ? "d-flex ms-3 mt-3 flex-wrap gap-3" : ""}>
                    {dataFile.length > 0 ?
                      dataFile.map((data, index) => (
                        <Card className="position-relative "
                          key={data.id}
                          styles={{ body: { padding: 0 } }}
                          style={{
                            width: 175,
                            border: currentFileSelect?.id === data.id ? '2px solid #2f54eb' : '1px solid #d9d9d9',
                            position: 'relative',
                            overflow: 'hidden',
                            transition: 'all 0.3s ease',
                            zIndex: "10"
                          }}
                          hoverable
                          onMouseEnter={() => setHover(data.id)}
                          onMouseLeave={() => setHover(null)}
                          onClick={() => handleClick(data.id)}
                        >
                          <Tag color="black" style={{ zIndex: "100", position: 'absolute', top: 0, left: 0 }}>{data?.extention?.toUpperCase()}</Tag>
                          <TemplateExtension style={{ height: 180, maxHeight: 180 }} extension={data?.extention} url={urlApi(data?.url)} />
                          <div className='ps-2 pe-1  py-1 d-flex justify-content-between nowrap border-top'>
                            <div>{`${data?.name.substring(0, 15)}${data?.name.length > 15 ? "..." : ""}`}</div>
                            {(currentFileSelect?.id === data.id || hover === data.id) && (
                              <div style={{
                                transition: 'opacity 0.2s',
                                opacity: hover === data?.id ? 1 : currentFileSelect.id === data.id ? 1 : 0
                              }}>
                                ✔
                              </div>
                            )}
                          </div>
                        </Card>
                      ))
                      : <Empty />}
                  </div></div>) :
                <Empty />
              }
            </Content>
            {currentFolderSelect !== undefined ||  (filter.status === "List" && filter.request.filters !== undefined) ? (
              dataFile.length > 0 ?
                <Footer>
                  <Pagination className="mt-4" align="center" onChange={handlePageChange} current={filter?.request.pageIndex || 1} defaultCurrent={1} pageSize={21} total={totalFile} />
                </Footer>
                : <></>
            ) : <></>
            }
          </Layout>
        </Layout>
      </Modal>
    </div>
  )
}
export default FileManager