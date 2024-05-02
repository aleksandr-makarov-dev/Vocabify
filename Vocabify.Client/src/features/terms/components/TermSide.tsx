import { cn } from "@/lib/utils";
import { FC } from "react";

interface TermSideProps {
  text: string;
  image?: string;
}

const TermSide: FC<TermSideProps> = ({ text, image }) => {
  return (
    <div
      className={cn(
        "flex flex-col-reverse sm:grid grid-cols-2 gap-x-10 gap-y-2 items-center min-h-48",
        {
          "sm:flex": !image,
        }
      )}
    >
      <p className="text-2xl text-center">{text}</p>
      {image && (
        <img
          className="w-48 h-48 object-center object-cover rounded-md"
          src={image}
          alt="img"
        />
      )}
    </div>
  );
};

export default TermSide;
