import com.itextpdf.kernel.colors.ColorConstants;
import com.itextpdf.kernel.pdf.PdfDocument;
import com.itextpdf.kernel.pdf.PdfWriter;
import com.itextpdf.layout.Document;
import com.itextpdf.layout.element.Cell;
import com.itextpdf.layout.element.Paragraph;
import com.itextpdf.layout.element.Table;

import java.io.File;
import java.io.FileOutputStream;

import org.apache.log4j.BasicConfigurator;
import org.apache.log4j.Level;
import org.apache.log4j.Logger;

public class OddEven {
    private static final String DEST = "results/oddEven.pdf";

    static {
        new File(DEST).getParentFile().mkdirs();
    }

    public static void main(String[] args) {
        try {
            Logger logger = Logger.getLogger(HTML.class);
            logger.setLevel(Level.WARN);
            BasicConfigurator.configure();
            new OddEven().createPdf();
            System.out.println("Done");
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void createPdf() throws Exception {
        PdfDocument pdf = new PdfDocument(new PdfWriter(new FileOutputStream(DEST)));
        Document doc = new Document(pdf);
        Table table = new Table(6);
        for (int i = 0; i < 600; i++) {
            Cell cell = new Cell();
            //TODO Add a conditional statement that changes the background color to gray if i is odd
            if (i%2!=0) {
                cell.setBackgroundColor(ColorConstants.LIGHT_GRAY);
            }
            table.addCell(cell.add(new Paragraph(Integer.toString(i))));
        }
        doc.add(table);
        pdf.close();
    }
}
