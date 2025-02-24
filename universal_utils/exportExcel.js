import * as XLSX from 'xlsx'
import { ElMessage } from "element-plus"
import globalUtils from './globalUtils';
import XLSXStyle from 'xlsx-style-vite'


/**
 * 导出数据成excel表格
 * @param {Array} list 数据列表
 * @param {string} fileName 导出的文件名
 * @param {string} sheetName 导出的sheetname名字
 * @param {Array} headerNames 表头的中英文对照
 * @returns 
 */
const toExport = (list, fileName, sheetName, headerNames) => {
    if (!list || list.length == 0) {
        ElMessage.warning("请选择数据再导出Excel");
        return;
    }

    try {
        const exportData = getExcelData(list, headerNames);

        const workSheet = XLSX.utils.json_to_sheet(exportData);
        const workBook = XLSX.utils.book_new();
        XLSX.utils.book_append_sheet(workBook, workSheet, sheetName);

        const exportFileName = fileName + globalUtils.generateCurrentTimestamp() + ".xlsx";
        XLSX.writeFile(workBook, exportFileName);
    } catch (error) {
        console.error('导出失败:', error);
        ElMessage.error('导出失败，请稍后重试');
    }
}


/**
 * 
 * @param {string} fileName 导出的文件名
 * @param {Array} dataList 对象数组，包含sheetname名，tableData数据列表，headerNames表头中英文映射集。一个sheet对应一个数组。
 * @param {Function} rowBgColorCallback 控制行背景的颜色显示的方法
 * @returns 
 */
const toExportAsStyle = (fileName, dataList, rowBgColorCallback) => {
    if (!dataList || dataList.length == 0) {
        ElMessage.warning("请选择数据再导出Excel");
        return;
    }
    try {
        //创建工作簿
        const wb = XLSX.utils.book_new();
        bookAppendSheet(wb, dataList, rowBgColorCallback);
        //blob下载
        const exportFileName = fileName + globalUtils.generateCurrentTimestamp() + '.xlsx';
        const buffer = XLSXStyle.write(wb, {type: 'binary'});
        const blob = new Blob([s2ab(buffer)], { type: 'application/octet-stream' });
        const link = document.createElement('a');
        link.href = URL.createObjectURL(blob);
        link.download = exportFileName;
        link.click();
    } catch (error) {
        console.error('导出失败:', error);
        ElMessage.error('导出失败，请稍后重试');
    }
}


const getExcelData = (list, headerNames) => {
    return list.map(item => {
        const newItem = {};
        headerNames.forEach(header => {
            // 获取属性值，如果是 undefined 或 null 则替换为空字符串
            const value = item[header.prop];
            newItem[header.label] = (value === undefined || value === null) ? '' : value;
        });
        return newItem;
    });
}

const s2ab = (s) => {
    const buf = new ArrayBuffer(s.length);
    const view = new Uint8Array(buf);
    for (var i = 0; i != s.length; ++i) view[i] = s.charCodeAt(i) & 0xff;
    return buf;
};

const bookAppendSheet = (wb, dataList, rowBgColorCallback = null) => {
    dataList.forEach(item => {
        const sheetName = item.sheetName;
        const tableData = item.tableData;
        const headerNames = item.headerNames;

        const exportData = getExcelData(tableData, headerNames);
        const workSheet = XLSX.utils.json_to_sheet(exportData);
        Object.keys(workSheet).forEach(cell => {
            const cellRef = XLSXStyle.utils.decode_cell(cell);
            const rowIndex = cellRef.r;

            if (rowIndex === 0) {
                return;
            }
        const row = tableData[rowIndex-1];
            let rowBgColor = 'FFFFFF';
            if (rowBgColorCallback) {
                rowBgColor = rowBgColorCallback(row);
            }
            if (rowBgColor) {
                rowBgColor = rowBgColor.replace(/^#/, '');
            }
            if (workSheet[cell] instanceof Object) {
                workSheet[cell].s = { fill: { fgColor: { rgb: rowBgColor } }, alignment: { horizontal: "center" } };
            }
        });
        XLSX.utils.book_append_sheet(wb, workSheet, sheetName);
    });
}


export default {
    toExport,
    toExportAsStyle,
}