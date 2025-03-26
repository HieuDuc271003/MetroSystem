import { useEffect, useState } from "react";
import { motion } from "framer-motion";
import { Pencil, Trash2 } from "lucide-react";

const UserManagement = () => {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetch("https://metroldirection.azurewebsites.net/api/admin/users")
      .then((res) => res.json())
      .then((data) => {
        setUsers(data);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Error fetching users:", err);
        setError("Failed to load users");
        setLoading(false);
      });
  }, []);

  const updateUserStatus = (email) => {
    fetch(`https://metroldirection.azurewebsites.net/api/admin/users/${email}/status`, {
      method: "PUT",
    })
      .then((res) => {
        if (!res.ok) throw new Error("Failed to update status");
        return res.json();
      })
      .then(() => {
        alert("User status updated successfully");
        setUsers((prev) =>
          prev.map((user) =>
            user.email === email ? { ...user, status: user.status === "active" ? "inactive" : "active" } : user
          )
        );
      })
      .catch((err) => {
        console.error("Error updating status:", err);
        alert("Failed to update user status");
      });
  };

  return (
    <motion.div className="p-6 bg-gray-800 rounded-lg" initial={{ opacity: 0 }} animate={{ opacity: 1 }}>
      <h2 className="text-xl font-bold text-white mb-4">User Management</h2>
      {loading && <p className="text-white">Loading users...</p>}
      {error && <p className="text-red-500">{error}</p>}
      {!loading && !error && (
        <table className="w-full text-white border-collapse border border-gray-700">
          <thead>
            <tr className="bg-gray-700">
              <th className="p-2 border border-gray-600">ID</th>
              <th className="p-2 border border-gray-600">Role</th>
              <th className="p-2 border border-gray-600">Display Name</th>
              <th className="p-2 border border-gray-600">Email</th>
              <th className="p-2 border border-gray-600">Actions</th>
            </tr>
          </thead>
          <tbody>
            {users.map((user) => (
              <tr key={user.email} className="text-center">
                <td className="p-2 border border-gray-600">{user.id}</td>
                <td className="p-2 border border-gray-600">{user.role}</td>
                <td className="p-2 border border-gray-600">{user.displayName}</td>
                <td className="p-2 border border-gray-600">{user.email}</td>
                <td className="p-2 border border-gray-600 flex justify-center gap-2">
                  <button className="px-2 py-1 bg-green-500 hover:bg-green-600 text-white rounded">
                    <Pencil size={16} />
                  </button>
                  <button className="px-2 py-1 bg-red-500 hover:bg-red-600 text-white rounded">
                    <Trash2 size={16} />
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </motion.div>
  );
};

export default UserManagement;