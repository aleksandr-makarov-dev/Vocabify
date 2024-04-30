import { FC } from "react";
import NavIcon from "./NavIcon";

interface FooterProps {
  text: string;
  navIcons: Array<{ icon: any; link: string }>;
}

const Footer: FC<FooterProps> = ({ text, navIcons }) => {
  return (
    <footer className="bg-muted">
      <div className="max-w-screen-2xl flex items-center p-5">
        <div className="w-full">
          <p className="text-muted-foreground">{text}</p>
        </div>
        <div>
          {navIcons.map((item) => (
            <NavIcon key={item.link} {...item} />
          ))}
        </div>
      </div>
    </footer>
  );
};

export default Footer;
