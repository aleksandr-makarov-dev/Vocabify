import { Button } from "@/components/ui/button";
import { GraduationCap } from "lucide-react";
import { FC } from "react";
import { useNavigate } from "react-router-dom";

interface SetToolbarProps {
  setId: string;
}

const SetToolbar: FC<SetToolbarProps> = ({ setId }) => {
  const navigate = useNavigate();

  return (
    <nav className="flex flex-col sm:grid grid-cols-4">
      <Button
        icon={
          <GraduationCap
            className="w-5 h-5 text-blue-500"
            fill="currentColor"
          />
        }
        variant="outline"
        size="lg"
        onClick={() => navigate(`/${setId}/practice`)}
      >
        Practice
      </Button>
    </nav>
  );
};

export default SetToolbar;
