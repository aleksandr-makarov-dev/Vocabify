import { UserSearch } from "lucide-react";
import { FC } from "react";

const UsersEmptyView: FC = () => {
  return (
    <div className="flex flex-col items-center py-10 text-center">
      <UserSearch className="w-16 h-16" />
      <div className="mb-5 mt-2">
        <p className="text-lg font-medium">No users found</p>
        <p className="text-gray-700">No users are waiting for the access</p>
      </div>
    </div>
  );
};

export default UsersEmptyView;
