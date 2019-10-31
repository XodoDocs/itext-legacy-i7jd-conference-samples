import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;

import com.itextpdf.html2pdf.ConverterProperties;
import org.apache.log4j.BasicConfigurator;
import org.apache.log4j.Level;
import org.apache.log4j.Logger;

import com.itextpdf.html2pdf.HtmlConverter;

public class HTML {
    private static final String DEST = "results/html.pdf";
    private static final String HTML = "src/main/resources/html/hello.html";

    static {
        new File(DEST).getParentFile().mkdirs();
    }

    public static void main(String[] args) {
        try {
            Logger logger = Logger.getLogger(HTML.class);
            logger.setLevel(Level.WARN);
            BasicConfigurator.configure();
            new HTML().createPdf();
            System.out.println("Done");
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void createPdf() throws Exception {
        //TODO Create an input File or InputStream
        FileInputStream input = new FileInputStream(HTML);
        //TODO Create an output File or OutputStream
        FileOutputStream output = new FileOutputStream(DEST);

        ConverterProperties converterProperties = new ConverterProperties();
        converterProperties.setBaseUri(new File(HTML).getParent());
        HtmlConverter.convertToPdf(input, output, converterProperties);
    }
}
