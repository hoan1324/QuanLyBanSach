import { create } from "zustand";

const useFileManagerStore = create((set, get) => ({
  open: false,
  collapsed: false,
  dataFolder: [],
  dataFile: [],
  currentFileSelect: undefined,
  currentFolderSelect: undefined,
  status: "folder",
  filter: {
    status: "List",
    request: {
      pageIndex: 1,
      orderByColumn: "Name",
    },
  },
  totalFile: 0,
  hover: null,

  // Actions
  setOpen: (value) => set({ open: value }),
  setCollapsed: (value) => set({ collapsed: value }),
  setDataFolder: (data) => set({ dataFolder: data }),
  setDataFile: (data) => set({ dataFile: data }),
  setCurrentFileSelect: (file) => set({ currentFileSelect: file }),
  setCurrentFolderSelect: (folder) => set({ currentFolderSelect: folder }),
  setStatus: (status) => set({ status }),
  setFilter: (filter) => set({ filter }),
  setTotalFile: (total) => set({ totalFile: total }),
  setHover: (hover) => set({ hover }),

  // Fetch data actions
  fetchData: async (service) => {
    const attachmentFolder = await service.getListDropdown();
    set({ dataFolder: attachmentFolder });
  },
  fetchDataFile: async (service, filter) => {
    if (filter.status === "List") {
      if (!filter?.request?.filters) {
        return;
      }
      const { data, total } = await service.getList(filter.request);
      set({ dataFile: data, totalFile: total });
    } else {
      const { data, total } = await service.getListDiffirent(
        "getFileInFolder",
        true,
        [filter.request]
      );
      set({ dataFile: data, totalFile: total });
    }
  },
}));

export default useFileManagerStore;
