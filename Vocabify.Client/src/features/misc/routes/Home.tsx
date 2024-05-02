import AudioButton from "@/components/common/AudioButton";
import { FC } from "react";

export const Home: FC = () => {
  return (
    <div>
      <p>Hello!</p>
      <AudioButton
        queue={[
          "https://quizlet.com/tts/fi2.mp3?v=1&b=eW1ww6RyaXN0w7Zuc3VvamVsdSAoeW1ww6RyaXN0w7YgLSBlbnZpcm9ubWVudCk&s=bza4Eg7P",
        ]}
      />
    </div>
  );
};
