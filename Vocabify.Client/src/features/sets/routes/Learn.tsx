import Header from "@/components/common/Header";
import { FC } from "react";
import SetsList from "../components/SetsList";

export const Learn: FC = () => {
  // const { addToAudioQueue } = useAudioPlayer();

  // useEffect(() => {
  //   addToAudioQueue(
  //     "https://quizlet.com/tts/fi2.mp3?v=1&b=asOkw6Rkw6Q&s=T8ukIpQG"
  //   );
  // }, []);

  return (
    <div className="space-y-10">
      <Header
        title="Learn study sets"
        subtitle="This is test subtitle for the page"
      />
      <SetsList />
    </div>
  );
};
