import React, { useState } from "react";
import axios from "axios";

const SearchBus = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [results, setResults] = useState([]);
  const [loading, setLoading] = useState(false);

  const handleSearch = async () => {
    if (!searchTerm.trim()) return;
    setLoading(true);
    try {
      const response = await axios.post(
        "http://timbus.vn/Engine/Business/Search/action.ashx",
        new URLSearchParams({ act: "searchfull", typ: "1", key: searchTerm })
      );

      let data = response.data;
      if (typeof data === "string" && /^[0-9a-fA-F]+$/.test(data)) {
        // Nếu dữ liệu trả về là hex, thử giải mã
        const buffer = Buffer.from(data, "hex");
        data = buffer.toString("utf8");
      }

      console.log("Dữ liệu API:", data);

      // Nếu dữ liệu có thể parse thành JSON, hiển thị danh sách xe
      try {
        const jsonData = JSON.parse(data);
        setResults(jsonData.dt?.Data || []);
      } catch (err) {
        setResults([{ ObjectID: "Lỗi", Name: "Không thể giải mã", FleedCode: "" }]);
      }
    } catch (error) {
      console.error("Lỗi khi gọi API:", error);
      setResults([{ ObjectID: "Lỗi", Name: "Không thể kết nối API", FleedCode: "" }]);
    }
    setLoading(false);
  };

  return (
    <div>
      <h2>Tìm tuyến xe buýt</h2>
      <input
        type="text"
        placeholder="Nhập tuyến xe..."
        value={searchTerm}
        onChange={(e) => setSearchTerm(e.target.value)}
      />
      <button onClick={handleSearch} disabled={loading}>
        {loading ? "Đang tìm..." : "Tìm kiếm"}
      </button>

      <ul>
        {results.map((bus, index) => (
          <li key={index}>
            <strong>ID:</strong> {bus.ObjectID} | <strong>Tên:</strong> {bus.Name} | <strong>Xe:</strong> {bus.FleedCode}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default SearchBus;
