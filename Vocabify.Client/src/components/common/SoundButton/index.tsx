import { Button } from "@/components/ui/button";
import { Volume1, Volume2 } from "lucide-react";
import { FC, useState } from "react";

const SoundButton: FC<{}> = ({}) => {
  const [isPlaying, setIsPlaying] = useState<boolean>();

  return (
    <Button size="icon" variant="secondary">
      {isPlaying ? (
        <Volume2 className="w-5 h-5" />
      ) : (
        <Volume1 className="w-5 h-5" />
      )}
    </Button>
  );
};

export default SoundButton;
