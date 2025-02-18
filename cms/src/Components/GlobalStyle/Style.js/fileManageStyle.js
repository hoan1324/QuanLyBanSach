const styleLayout = {
    minHeight: '800px'
  }
  const styleHeader = {
    height: "fit-content"
  }
  const styleCard = (id, idData) => {
    return {
      width: 175,
      border: id === idData ? '2px solid #2f54eb' : '1px solid #d9d9d9',
      position: 'relative',
      overflow: 'hidden',
      transition: 'all 0.3s ease',
      zIndex: "10"
    }
  }


  const styleDiv = (hover, idData, idCurrent) => {
    return {
      transition: 'opacity 0.2s',
      opacity: hover === idData ? 1 : idCurrent === idData ? 1 : 0
    }
  }
  export {styleLayout,styleDiv,styleCard,styleHeader}