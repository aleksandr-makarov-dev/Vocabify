import { Button } from "@/components/ui/button";
import { FolderSearch, Plus } from "lucide-react";
import { FC } from "react";
import { useNavigate } from "react-router-dom";

const SetsEmptyView: FC = () => {
  const navigate = useNavigate();

  return (
    <div className="flex flex-col items-center py-10 text-center">
      <FolderSearch className="w-16 h-16" />
      <div className="mb-5 mt-2">
        <p className="text-lg font-medium">No sets found</p>
        <p className="text-gray-700">Get started by creating a new set.</p>
      </div>
      <Button
        icon={<Plus className="w-5 h-5" />}
        onClick={() => navigate("/create")}
      >
        New set
      </Button>
    </div>
  );
};

export default SetsEmptyView;
